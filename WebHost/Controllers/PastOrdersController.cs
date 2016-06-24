namespace WebHost.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Domain.Features.PastOrders;
    using MediatR;
    using WebHost.Models.PastOrders;

    [RoutePrefix("past-orders")]
    public class PastOrdersController : Controller
    {
        private readonly IMediator mediator;

        public PastOrdersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route]
        public async Task<ActionResult> Index(ListQuery query)
        {
            var result =
                await this.mediator.SendAsync(query);

            var model = new IndexViewModel(result, query);

            return Request.IsAjaxRequest()
                ? (ActionResult)PartialView("_Index", model)
                : View(model);
        }
    }
}