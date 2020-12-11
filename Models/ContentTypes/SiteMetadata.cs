using System.Linq;

namespace Kentico.Kontent.Statiq.Lumen.Models
{
    public partial class SiteMetadata
    {
        public Author SiteAuthor => Author.OfType<Author>().First();
    }
}