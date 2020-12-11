namespace Kentico.Kontent.Statiq.Lumen.Models.ViewModels
{
    public class PageViewModel : ViewModelBase
    {
        public string Title { get; private set; }

        public string Content { get; private set; }

        public PageViewModel(string title, string content, SidebarViewModel sidebar) : base(sidebar.Metadata)
        {
            Title = title;
            Content = content;
        }
    }
}
