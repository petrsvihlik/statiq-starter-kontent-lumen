using Kentico.Kontent.Delivery.Abstractions;

namespace Kentico.Kontent.Statiq.Lumen.Models
{
    public interface ITitleProvider
    {
        string Title { get; }

        IContentItemSystemAttributes System { get; }

        string ElementCodename { get; }
    }
}
