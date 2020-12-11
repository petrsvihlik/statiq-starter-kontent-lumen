using Kentico.Kontent.Delivery.Abstractions;

namespace Kentico.Kontent.Statiq.Lumen.Models
{
    public interface ITwitterCard
    {
        string TwitterTitle { get; }
        string TwitterDescription { get; }
        string TwitterCreator { get; }
        string TwitterSite => TwitterCreator;
        IAsset TwitterImage { get; }
        string TwitterCard => "summary_large_image";
    }
}
