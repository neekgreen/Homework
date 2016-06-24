namespace WebHost.Conventions.Html
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using HtmlTags;

    public static class FormPrimitiveExtensions
    {
        public static HtmlTag InputBlock<T>(this HtmlTagsHelper<T> helper, Expression<Func<T, object>> expression, Action<HtmlTag> inputModifier = null, Action<HtmlTag> validationMessageModifier = null) where T : class
        {
            inputModifier = inputModifier ?? (_ => { });
            validationMessageModifier = validationMessageModifier ?? (_ => { });

            var divTag = new DivTag();

            var inputTag = helper.Input(expression);
            inputTag.AddClass("form-control");
            inputModifier(inputTag);

            var validationMessageTag = helper.ValidationMessage(expression);
            validationMessageModifier(validationMessageTag);

            divTag.Append(inputTag);
            divTag.Append(validationMessageTag);

            return divTag;
        }

        public static HtmlTag FormBlock<T>(this HtmlTagsHelper<T> helper, Expression<Func<T, object>> expression, Action<HtmlTag> labelModifier = null, Action<HtmlTag> inputBlockModifier = null, Action<HtmlTag> inputModifier = null) where T : class
        {
            labelModifier = labelModifier ?? (_ => { });
            inputBlockModifier = inputBlockModifier ?? (_ => { });

            var divTag = new DivTag();
            divTag.AddClass("form-group");

            var labelTag = helper.Label(expression);
            labelModifier(labelTag);

            var inputBlockTag = helper.InputBlock(expression, inputModifier);
            inputBlockModifier(inputBlockTag);

            divTag.Append(labelTag);
            divTag.Append(inputBlockTag);

            return divTag;
        }
    }
}