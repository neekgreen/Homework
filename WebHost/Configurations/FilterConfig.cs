namespace WebHost.Configurations
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using WebHost.Conventions;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new AuthorizeAttribute());
            filters.Add(new ModelValidationActionFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }
}