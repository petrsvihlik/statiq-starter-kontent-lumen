using System.Collections.Generic;
using System.Linq;

namespace Kentico.Kontent.Statiq.Lumen.Models
{
    public partial class Homepage
    {
        public IEnumerable<Page> MenuItems => Subpages.OfType<Page>();
    }
}