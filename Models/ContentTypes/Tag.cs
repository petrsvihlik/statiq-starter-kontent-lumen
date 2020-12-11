namespace Kentico.Kontent.Statiq.Lumen.Models
{
    public partial class Tag : ITitleProvider
    {
        public string ElementCodename => TitleCodename;
    }
}