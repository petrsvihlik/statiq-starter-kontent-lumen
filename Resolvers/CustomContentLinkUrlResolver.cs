using Kentico.Kontent.Delivery.Abstractions;
using System.Threading.Tasks;

namespace Kentico.Kontent.Statiq.Lumen.Resolvers
{
    public class CustomContentLinkUrlResolver : IContentLinkUrlResolver
    {
        public Task<string> ResolveLinkUrlAsync(IContentLink link)
        {
            // Resolves URLs to content items based on the 'accessory' content type
            return Task.FromResult(link.ContentTypeCodename switch
            {
                "post" => $"/Post/Details/{link.UrlSlug}",
                _ => "/404",
            });
        }

        public Task<string> ResolveBrokenLinkUrlAsync()
        {
            // Resolves URLs to unavailable content items
            return Task.FromResult("/404");
        }
    }
}