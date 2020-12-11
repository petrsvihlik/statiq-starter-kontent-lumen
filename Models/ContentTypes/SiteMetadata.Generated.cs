// This code was generated by a kontent-generators-net tool 
// (see https://github.com/Kentico/kontent-generators-net).
// 
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated. 
// For further modifications of the class, create a separate file with the partial class.

using System;
using System.Collections.Generic;
using Kentico.Kontent.Delivery.Abstractions;

namespace Kentico.Kontent.Statiq.Lumen.Models
{
    public partial class SiteMetadata
    {
        public const string Codename = "site_metadata";
        public const string AuthorCodename = "author";
        public const string CopyrightCodename = "copyright";
        public const string SubtitleCodename = "subtitle";
        public const string TitleCodename = "title";

        public IEnumerable<object> Author { get; set; }
        public string Copyright { get; set; }
        public string Subtitle { get; set; }
        public IContentItemSystemAttributes System { get; set; }
        public string Title { get; set; }
    }
}