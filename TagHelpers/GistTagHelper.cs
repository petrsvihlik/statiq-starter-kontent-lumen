using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace Kentico.Kontent.Statiq.Lumen.TagHelpers
{
    [HtmlTargetElement("gist", TagStructure = TagStructure.NormalOrSelfClosing, Attributes = "id")]
    public class GistTagHelper : TagHelper
    {
        [HtmlAttributeName("id")]
        public Guid Id { get; set; }

        [HtmlAttributeName("username")]
        public string Username { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var id = Id.ToString("N");
            var username = !string.IsNullOrWhiteSpace(Username) ? Username + "/" : string.Empty;
            output.TagName = "script";
            output.Attributes.SetAttribute("src", $"https://gist.github.com/{username}{id}.js");
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
