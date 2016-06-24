namespace WebHost.Conventions.Html
{
    using System;
    using System.Linq;
    using HtmlTags;
    using HtmlTags.Conventions;
    using HtmlTags.Conventions.Elements;

    public class ValidationMessageBuilder : IElementBuilder
    {
        HtmlTag ITagBuilder.Build(ElementRequest request)
        {
            return
                new DivTag()
                    .AddClass("error")
                    .Attr("style", "display: none;")
                    .Name(request.ElementId)
                    .Data("error", request.ElementId);
        }
    }
}