namespace WebHost.Conventions.Html
{
    using System;
    using System.Linq;
    using HtmlTags;

    public static class HtmlTagExtensions
    {
        public static HtmlTag AddPlaceholder(this HtmlTag tag, string placeholder)
        {
            return tag.Attr("placeholder", placeholder);
        }

        public static HtmlTag AddPattern(this HtmlTag tag, string pattern)
        {
            return tag.Data("pattern", pattern);
        }

        public static HtmlTag AutoCapitalize(this HtmlTag tag)
        {
            return tag.Data("autocapitalize", "true");
        }
        
        public static HtmlTag NoSpellCheck(this HtmlTag tag)
        {
            return tag.Attr("spellcheck", "false");
        }
        
        public static HtmlTag TabIndex(this HtmlTag tag, string tabindex)
        {
            return tag.Attr("tabindex", tabindex);
        }

        public static HtmlTag NoTabIndex(this HtmlTag tag)
        {
            return tag.Attr("tabindex", "-1");
        }
    }
}