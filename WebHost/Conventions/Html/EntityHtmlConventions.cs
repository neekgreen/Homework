namespace WebHost.Conventions.Html
{
    using System;
    using System.Linq;
    using HtmlTags;
    using HtmlTags.Conventions;

    public class EntityHtmlConventions : HtmlConventionRegistry
    {
        public EntityHtmlConventions()
        {
            Editors.IfPropertyIs<byte[]>()
                .BuildBy(a => new HiddenTag().Value(Convert.ToBase64String(a.Value<byte[]>())));

            Editors.Modifier<EnumDropDownModifier>();
            Editors.Modifier<CommentTextAreaModifier>();
        }
    }
}