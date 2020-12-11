namespace Kentico.Kontent.Statiq.Lumen.Models.ViewModels
{
    public class PostViewModel : ViewModelBase
    {
        public Article Article { get; private set; }

        public PostViewModel(Article article, SiteMetadata metadata) : base(metadata)
        {
            Article = article;
        }
    }
}
