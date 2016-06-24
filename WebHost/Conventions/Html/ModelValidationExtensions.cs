namespace WebHost.Conventions.Html
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using HtmlTags;
    using HtmlTags.Conventions;
    using HtmlTags.Reflection;
    using HtmlTags.Conventions.Elements;

    public static class ModelValidationExtensions
    {
        public static HtmlTag ValidationMessage<T>(this HtmlHelper<T> helper, Expression<Func<T, object>> expression) where T : class
        {
            // MVC code don't ask me I just copied
            var expressionText = ExpressionHelper.GetExpressionText(expression);
            var fullHtmlFieldName
                = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expressionText);

            if (!helper.ViewData.ModelState.ContainsKey(fullHtmlFieldName))
                return new NoTag();

            ModelState modelState = helper.ViewData.ModelState[fullHtmlFieldName];
            ModelErrorCollection modelErrorCollection = modelState == null ? null : modelState.Errors;
            ModelError error = modelErrorCollection == null || modelErrorCollection.Count == 0 ? null : modelErrorCollection.FirstOrDefault(m => !string.IsNullOrEmpty(m.ErrorMessage)) ?? modelErrorCollection[0];

            if (error == null)
                return new NoTag();
            // End of MVC code

            var request = new ElementRequest(expression.ToAccessor())
            {
                Model = helper.ViewData.Model
            };
            
            var htmlTagGenerator = GetGenerator<T>(helper.ViewData.Model);
            var htmlTag = htmlTagGenerator.TagFor(request, CategoryNames.ValidatorMessage);

            htmlTag.Text(error.ErrorMessage);

            return htmlTag;
        }

        private static IElementGenerator<T> GetGenerator<T>(T model) where T : class
        {
            var conventionLibrary =
                DependencyResolver.Current.GetService<HtmlConventionLibrary>();

            return ElementGenerator<T>.For(conventionLibrary, t => DependencyResolver.Current.GetService(t), model);
        }
    }
}