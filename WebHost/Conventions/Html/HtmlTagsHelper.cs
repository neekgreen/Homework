namespace WebHost.Conventions.Html
{
    using System;
    using System.Web.Mvc;

    public class HtmlTagsHelper<T>
    {
        public HtmlTagsHelper(HtmlHelper<T> htmlHelper)
        {
            this.HtmlHelper = htmlHelper;
        }

        public HtmlHelper<T> HtmlHelper { get; private set; }
    }
}