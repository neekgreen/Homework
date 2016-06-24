namespace WebHost.Conventions.Html
{
    using System;
    using System.Web.Mvc;

    public static class HtmlHelperHtmlTagsExtension
    {
        public static HtmlTagsHelper<T> HtmlTags<T>(this HtmlHelper<T> helper)
        {
            return new HtmlTagsHelper<T>(helper);
        }
    }
}