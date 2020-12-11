using Statiq.Common;
using Statiq.Core;

namespace Kentico.Kontent.Statiq.Lumen.Pipelines
{
    public class CopyAssetsPipeline : Pipeline
    {
        public CopyAssetsPipeline()
        {
            InputModules = new ModuleList
            {
                new CopyFiles("./assets/{css,fonts,js,img}/**/*", "./*.{png,ico,webmanifest}")
            };
        }
    }
}
