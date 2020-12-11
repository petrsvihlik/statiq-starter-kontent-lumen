namespace Kentico.Kontent.Statiq.Lumen.Models
{
    public partial class Category : ITitleProvider
    {
        public string ElementCodename => TitleCodename;
    }
}