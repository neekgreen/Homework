namespace WebHost.Conventions.Html
{
    using System;
    using System.Linq;
    using HtmlTags.Conventions;
    using HtmlTags.Conventions.Elements;

    public class CommentTextAreaModifier : IElementModifier
    {
        bool ITagModifier.Matches(ElementRequest token)
        {
            return 
                token.Accessor.PropertyType == typeof(string) 
                && token.Accessor.Name.EndsWith("comment", StringComparison.OrdinalIgnoreCase);
        }

        void ITagModifier.Modify(ElementRequest request)
        {
            request.CurrentTag.RemoveAttr("type");
            request.CurrentTag.TagName("textarea");
            request.CurrentTag.Attr("rows", 5);
            request.CurrentTag.Attr("cols", 5);
        }
    }
}