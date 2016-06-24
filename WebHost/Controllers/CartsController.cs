namespace WebHost.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Domain.Features.Carts;
    using MediatR;

    [RoutePrefix("carts")]
    public class CartsController : Controller
    {
        private readonly IMediator mediator;

        public CartsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route]
        public async Task<ActionResult> Index(SummaryQuery query)
        {
            query.Id = Guid.Parse("70063A92-940D-4934-8FA5-C15F7AF7600D");
            var result =
                await this.mediator.SendAsync(query);

            return PartialView("_Index", result);
        }

        [Route("update"), HttpPost]
        public async Task<ActionResult> Update(UpdateCommand command)
        {
            command.Id = Guid.Parse("70063A92-940D-4934-8FA5-C15F7AF7600D");
            var result =
                await this.mediator.SendAsync(command);

            return RedirectToAction("Index", new { command.Id });
        }

        [Route("submit"), HttpPost ]
        public async Task<ActionResult> Submit(SubmitCommand command)
        {
            command.Id = Guid.Parse("70063A92-940D-4934-8FA5-C15F7AF7600D");
            var result =
                await this.mediator.SendAsync(command);

            TempData["OrderNumber"] = result.OrderNumber;

            return this.JsonNet(new { redirect = Url.Action("Submitted") }); 
        }

        [Route("submitted")]
        public ActionResult Submitted()
        {
            return View();
        }
    }
}