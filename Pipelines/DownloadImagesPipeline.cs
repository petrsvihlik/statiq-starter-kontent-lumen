using Kontent.Statiq;
using Statiq.Common;
using Statiq.Core;
using System.Linq;

namespace Kentico.Kontent.Statiq.Lumen.Pipelines
{
    public class DownloadImagesPipeline : Pipeline
    {
        public DownloadImagesPipeline()
        {
            Dependencies.AddRange(nameof(PostsPipeline), nameof(HomePipeline));
            PostProcessModules = new ModuleList(
                // pull documents from other pipelines
                new ReplaceDocuments(Dependencies.ToArray()),
                new KontentDownloadImages()
            );
            OutputModules = new ModuleList(

                new WriteFiles()
            );
        }
    }
}