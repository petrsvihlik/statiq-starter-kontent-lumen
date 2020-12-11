using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Delivery.Urls.QueryParameters;
using Kentico.Kontent.Delivery.Urls.QueryParameters.Filters;
using Kentico.Kontent.Statiq.Lumen.Models;
using Kentico.Kontent.Statiq.Lumen.Models.ViewModels;
using Kontent.Statiq;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;
using System.Linq;

namespace Kentico.Kontent.Statiq.Lumen.Pipelines
{
    public class PagesPipeline : Pipeline
    {
        public PagesPipeline(IDeliveryClient deliveryClient)
        {
            Dependencies.AddRange(nameof(HomepagePipeline), nameof(SiteMetadataPipeline));
            InputModules = new ModuleList{
                new Kontent<Page>(deliveryClient)
                    .WithQuery(new IncludeTotalCountParameter(), new NotEmptyFilter("elements.body")),
                new SetDestination(Config.FromDocument((doc, ctx)  => new NormalizedPath($"pages/{doc.AsKontent<Page>().Url}/index.html" ))),
            };

            ProcessModules = new ModuleList {
                new MergeContent(new ReadFiles(patterns: "Index.cshtml") ),
                new RenderRazor()
                 .WithModel(Config.FromDocument((document, context) =>
                 {
                    var menuItem = document.AsKontent<Page>();
                    var model = new HomeViewModel(menuItem,
                                    new SidebarViewModel(
                                    context.Outputs.FromPipeline(nameof(HomepagePipeline)).Select(x => x.AsKontent<Homepage>()).FirstOrDefault(),
                                    context.Outputs.FromPipeline(nameof(SiteMetadataPipeline)).Select(x => x.AsKontent<SiteMetadata>()).FirstOrDefault(),
                                    false, menuItem.Url));
                    return model;
                 }
                 ))/*,
                new KontentImageProcessor()*/
            };

            OutputModules = new ModuleList {
                new WriteFiles(),
            };
        }
    }
}