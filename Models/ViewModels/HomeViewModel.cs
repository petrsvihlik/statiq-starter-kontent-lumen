namespace Kentico.Kontent.Statiq.Lumen.Models.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public Page Page { get; private set; }

        public PagedContent<Article> Articles { get; private set; }

        public SidebarViewModel Sidebar { get; private set; }

        public ITitleProvider TitleProvider { get; }

        public HomeViewModel(PagedContent<Article> articles, SidebarViewModel sidebar, ITitleProvider titleProvider = null) : this(sidebar, titleProvider)
        {
            Articles = articles;
        }

        public HomeViewModel(Page page, SidebarViewModel sidebar) : this(sidebar, page)
        {
            Page = page;
        }

        private HomeViewModel(SidebarViewModel sidebar, ITitleProvider titleProvider) : base(sidebar.Metadata)
        {
            Sidebar = sidebar;
            TitleProvider = titleProvider;
        }
    }
}
