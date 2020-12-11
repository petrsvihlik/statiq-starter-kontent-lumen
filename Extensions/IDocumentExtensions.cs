using Kentico.Kontent.Statiq.Lumen.Models;
using Statiq.Common;

namespace Kentico.Kontent.Statiq.Lumen.Extensions
{
    public static class IDocumentExtensions
    {
        public static PagedContent<TModel> AsPagedKontent<TModel>(this IDocument document)
        {
            return new PagedContent<TModel>(document);
        }
    }
}
