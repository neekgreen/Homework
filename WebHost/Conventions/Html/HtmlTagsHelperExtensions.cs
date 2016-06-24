namespace WebHost.Conventions.Html
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using HtmlTags;
    using HtmlTags.Conventions;
    using HtmlTags.Conventions.Elements;
    using HtmlTags.Reflection;

    public static class HtmlTagsHelperExtensions
    {
        public static HtmlTag Input<T>(this HtmlTagsHelper<T> helper, Expression<Func<T, object>> expression) where T : class
        {
            var generator = GetGenerator<T>(helper.HtmlHelper.ViewData.Model);

            return generator.InputFor(expression);
        }

        public static HtmlTag Label<T>(this HtmlTagsHelper<T> helper, Expression<Func<T, object>> expression) where T : class
        {
            var generator = GetGenerator<T>(helper.HtmlHelper.ViewData.Model);

            return generator.LabelFor(expression);
        }

        public static HtmlTag Display<T>(this HtmlTagsHelper<T> helper, Expression<Func<T, object>> expression) where T : class
        {
            var generator = GetGenerator<T>(helper.HtmlHelper.ViewData.Model);

            return generator.DisplayFor(expression);
        }

        public static HtmlTag ValidationMessage<T>(this HtmlTagsHelper<T> helper, Expression<Func<T, object>> expression) where T : class
        {
            var generator = GetGenerator<T>(helper.HtmlHelper.ViewData.Model);
            var request = new ElementRequest(expression.ToAccessor())
            {
                Model = helper.HtmlHelper.ViewData.Model
            };

            return generator.TagFor(request, CategoryNames.ValidatorMessage);
        }

        private static IElementGenerator<T> GetGenerator<T>(T model) where T : class
        {
            var conventionLibrary =
                DependencyResolver.Current.GetService<HtmlConventionLibrary>();

            return ElementGenerator<T>.For(conventionLibrary, t => DependencyResolver.Current.GetService(t), model);
        }
    }
}