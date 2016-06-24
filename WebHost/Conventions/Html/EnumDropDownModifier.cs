﻿namespace WebHost.Conventions.Html
{
    using System;
    using System.Linq;
    using HtmlTags;
    using HtmlTags.Conventions;
    using HtmlTags.Conventions.Elements;

    public class EnumDropDownModifier : IElementModifier
    {
        public bool Matches(ElementRequest token)
        {
            return token.Accessor.PropertyType.IsEnum;
        }

        public void Modify(ElementRequest request)
        {
            var enumType = request.Accessor.PropertyType;

            request.CurrentTag.RemoveAttr("type");
            request.CurrentTag.TagName("select");
            request.CurrentTag.Append(new HtmlTag("option"));

            foreach (var value in Enum.GetValues(enumType))
            {
                var optionTag = 
                    new HtmlTag("option")
                        .Value(value.ToString())
                        .Text(Enum.GetName(enumType, value));

                request.CurrentTag.Append(optionTag);
            }
        }
    }
}