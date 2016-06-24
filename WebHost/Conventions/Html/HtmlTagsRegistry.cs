namespace WebHost.Conventions.Html
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HtmlTags.Conventions;
    using StructureMap;

    public class HtmlTagsRegistry : Registry
    {
        public HtmlTagsRegistry()
        {
            var htmlConventionLibrary = new HtmlConventionLibrary();

            GetHtmlConventions()
                .ToList()
                .ForEach(t => t.Apply(htmlConventionLibrary));

            For<HtmlConventionLibrary>().Use(htmlConventionLibrary);
        }

        private IEnumerable<HtmlConventionRegistry> GetHtmlConventions()
        {
            yield return new EntityHtmlConventions();
            yield return new FormHtmlConventions();
            yield return new ModelValidationHtmlConventions();
            yield return new DefaultHtmlConventions();
        }
    }
}