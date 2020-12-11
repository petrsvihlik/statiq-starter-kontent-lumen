using System;
using System.Collections.Generic;

namespace Kentico.Kontent.Statiq.Lumen.Models
{
    public interface IOpenGraphArticle : IOpenGraph
    {
        string IOpenGraph.OgType => "article";
        DateTime OgPublishedTime { get; }
        DateTime OgModifiedTime { get; }
        DateTime OgExpirationTime => DateTime.MaxValue;
        IEnumerable<string> OgAuthor { get; }
        string OgSection { get; }
        IEnumerable<string> OgTag { get; }
    }
}
