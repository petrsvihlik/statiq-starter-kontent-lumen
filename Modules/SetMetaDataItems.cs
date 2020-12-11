using Statiq.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kentico.Kontent.Statiq.Lumen.Modules
{
    public class SetMetaDataItems : Module
    {
        private readonly Func<IDocument, IExecutionContext, Task<MetadataItems>> _getMetadata;

        public SetMetaDataItems(Func<IDocument, IExecutionContext, Task<MetadataItems>> getMetadata)
        {
            _getMetadata = getMetadata;
        }

        protected override async Task<IEnumerable<IDocument>> ExecuteInputAsync(IDocument input, IExecutionContext context)
        {
            var metadata = await _getMetadata(input, context);

            return metadata == null
                ? input.Yield()
                : input.Clone(metadata).Yield();
        }
    }
}