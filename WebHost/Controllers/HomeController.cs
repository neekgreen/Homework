namespace WebHost.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    [RoutePrefix("")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}