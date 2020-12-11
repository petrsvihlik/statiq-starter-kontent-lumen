using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Statiq.Lumen.Extensions;
using Kentico.Kontent.Statiq.Lumen.Models;
using Kentico.Kontent.Statiq.Lumen.Models.ViewModels;
using Kontent.Statiq;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;
using System.Collections.Generic;
using System.Linq;

namespace Kentico.Kontent.Statiq.Lumen.Pipelines
{
    public class TagsPipeline : Pipeline
    {
        public TagsPipeline(IDeliveryClient deliveryClient)
        {
            Dependencies.AddRange(nameof(PostsPipeline), nameof(HomepagePipeline), nameof(SiteMetadataPipeline));

            InputModules = new ModuleList
            {
                new ReadFiles(patterns: "Index.cshtml")
            };

            ProcessModules = new ModuleList {
                    new MergeDocuments()
                    {
                        new ReplaceDocuments(nameof(PostsPipeline)),
                        // Get docs from a different pipeline
                        new GroupDocuments(nameof(Tag)), // Group docs by the tag name
                    }.Reverse(),
                    new SetMetadata("SelectedTag", Config.FromDocument(doc => doc.GetChildren().FirstOrDefault().AsKontent<Article>().TagObjects.FirstOrDefault(t=>t.System.Codename == doc.GetString(Keys.GroupKey)))), // Copy group metadata to the group parent page
                    new ForEachDocument{ // For each tag
                        new ExecuteConfig(Config.FromDocument(groupDoc => new ModuleList
                        {
                            new ReplaceDocuments(Config.FromDocument<IEnumerable<IDocument>>(doc => doc.GetChildren())),
                            new PaginateDocuments(4), // Create pagination (docs will reside under a parent doc - a page)
                            new MergeContent(new ReadFiles(patterns: "Index.cshtml")),
                            new RenderRazor()
                                .WithModel(Config.FromDocument((document, context) =>
                                {
                                    var tag = groupDoc.Get<Tag>("SelectedTag");
                                    var model = new HomeViewModel(document.AsPagedKontent<Article>(),
                                                    new SidebarViewModel(
                                                    context.Outputs.FromPipeline(nameof(HomepagePipeline)).Select(x => x.AsKontent<Homepage>()).FirstOrDefault(),
                                                    context.Outputs.FromPipeline(nameof(SiteMetadataPipeline)).Select(x => x.AsKontent<SiteMetadata>()).FirstOrDefault(),
                                                    false, null), tag);
                                    return model;
                                })),
                        new SetDestination(Config.FromDocument((doc, ctx) => Filename(doc, groupDoc))) // Set output
                    }))
                }
            };

            OutputModules = new ModuleList {
                new WriteFiles(),
            };
        }

        private static NormalizedPath Filename(IDocument page, IDocument group)
        {
            var index = page.GetInt(Keys.Index);

            var tag = group.Get<Tag>("SelectedTag").Slug;

            return new NormalizedPath($"tag/{tag}/{(index > 1 ? $"{index}/" : "")}index.html");
        }
    }
}