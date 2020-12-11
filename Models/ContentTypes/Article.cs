using Kentico.Kontent.Delivery.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kentico.Kontent.Statiq.Lumen.Models
{
    public partial class Article : ITwitterCard, IOpenGraphArticle
    {
        public Author ArticleAuthor => Author.OfType<Author>().FirstOrDefault();

        public IEnumerable<Tag> TagObjects => Tags.OfType<Tag>();

        public Category SelectedCategory => Category.OfType<Category>().First();

        string ITwitterCard.TwitterCard => TwitterCard?.FirstOrDefault()?.Codename;

        public string TwitterTitle => OgTitle.Cascade(Title);

        public string TwitterDescription => OgDescription.Cascade(Description);

        public DateTime OgPublishedTime => PublishDate.Value;

        public DateTime OgModifiedTime => System.LastModified;

        public IEnumerable<string> OgAuthor => Author.OfType<Author>().Select(a => a.Name);

        public string OgSection => SelectedCategory.Title;

        public IEnumerable<string> OgTag => TagObjects.Select(t => t.Title);

        IAsset ITwitterCard.TwitterImage => TwitterImage?.FirstOrDefault().Cascade(OgImage?.FirstOrDefault());
    }
}