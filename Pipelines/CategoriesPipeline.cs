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
    public class CategoriesPipeline : Pipeline
    {
        public CategoriesPipeline(IDeliveryClient deliveryClient)
        {
            Dependencies.AddRange(nameof(PostsPipeline), nameof(HomepagePipeline),nameof(SiteMetadataPipeline));

            ProcessModules = new ModuleList {
                new ReplaceDocuments(nameof(PostsPipeline)), // Get docs from a different pipeline
                new GroupDocuments(nameof(Category)), // Group docs by the category name
                new SetMetadata(nameof(Article.SelectedCategory), Config.FromDocument(doc => doc.GetChildren().FirstOrDefault().Get<Category>(nameof(Article.SelectedCategory)))), // Copy group metadata to the group parent page
                new ForEachDocument{ // For each category
                    new ExecuteConfig(Config.FromDocument(groupDoc => new ModuleList
                    {
                        new ReplaceDocuments(Config.FromDocument<IEnumerable<IDocument>>(doc => doc.GetChildren())), // Remove the group parent page (to be able to apply Pagination)
                        new PaginateDocuments(4), // Create pagination (docs will reside under a parent doc - a page)
                        new MergeContent(new ReadFiles(patterns: "Index.cshtml")),
                        new RenderRazor()
                            .WithModel(Config.FromDocument((document, context) =>
                            {
                                var category = groupDoc.Get<Category>(nameof(Article.SelectedCategory));
                                var model = new HomeViewModel(document.AsPagedKontent<Article>(),
                                                new SidebarViewModel(
                                                context.Outputs.FromPipeline(nameof(HomepagePipeline)).Select(x => x.AsKontent<Homepage>()).FirstOrDefault(),
                                                context.Outputs.FromPipeline(nameof(SiteMetadataPipeline)).Select(x => x.AsKontent<SiteMetadata>()).FirstOrDefault(),
                                                false, null), category);
                                return model;
                            }
                            )),
                        new SetDestination(Config.FromDocument((doc, ctx) => Filename(doc, groupDoc))), // Set output
                    }))
                }

                /*,
                new KontentImageProcessor()*/
            };

            OutputModules = new ModuleList {
                new WriteFiles(),
            };
        }

        private static NormalizedPath Filename(IDocument page, IDocument group)
        {
            var index = page.GetInt(Keys.Index);
            var category = group.Get<Category>(nameof(Article.SelectedCategory)).Slug;
            return new NormalizedPath($"category/{category}/{(index > 1 ? $"{index}/" : "")}index.html");
        }
    }
}