namespace WebHost.Conventions
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Newtonsoft.Json;
    using System.Net;

    public class ModelValidationActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.Controller.ViewData.ModelState.IsValid)
            {
                if (filterContext.HttpContext.Request.HttpMethod == "GET")
                {
                    var result = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    filterContext.Result = result;
                }
                else
                {
                    var serializerSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                    var serializedModel = JsonConvert.SerializeObject(filterContext.Controller.ViewData.ModelState, serializerSettings);
                    var result = new ContentResult { Content = serializedModel, ContentType = "application/json" };

                    filterContext.HttpContext.Response.StatusCode = 400;
                    filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                    filterContext.Result = result;
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext) { }
    }
}