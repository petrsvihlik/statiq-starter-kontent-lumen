using Kentico.Kontent.Delivery.Abstractions;
using System.Collections.Generic;

namespace Kentico.Kontent.Statiq.Lumen.Models
{
    public interface IOpenGraph
    {
        virtual string OgType => "website";
        string OgTitle { get; }
        string OgDescription { get; }
        IEnumerable<IAsset> OgImage { get; }
    }
}
