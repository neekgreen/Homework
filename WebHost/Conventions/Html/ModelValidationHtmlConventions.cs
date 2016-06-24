namespace WebHost.Conventions.Html
{
    using System;
    using System.Linq;
    using HtmlTags.Conventions;

    public class ModelValidationHtmlConventions : HtmlConventionRegistry
    {
        public ModelValidationHtmlConventions()
        {
            ValidatorMessages.Always.BuildBy<ValidationMessageBuilder>();
        }

        protected ElementCategoryExpression ValidatorMessages
        {
            get { return new ElementCategoryExpression(Library.TagLibrary.Category(CategoryNames.ValidatorMessage).Profile(TagConstants.Default)); }
        }
    }
}