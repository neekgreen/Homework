namespace WebHost.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Domain.Features.Products;
    using MediatR;
    using WebHost.Models.Products;

    [RoutePrefix("products")]
    public class ProductsController : Controller
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
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

        [Route("new")]
        public ActionResult Create()
        {
            return View(new CreateCommand());
        }

        [HttpPost, Route("new")]
        public async Task<ActionResult> Create(CreateCommand command)
        {
            await this.mediator.SendAsync(command);

            return this.RedirectToActionJson("Index");
        }

        [Route("edit/{id:guid}")]
        public async Task<ActionResult> Update(UpdateQuery query)
        {
            var command = await this.mediator.SendAsync(query);

            return View(command);
        }

        [HttpPost, Route("edit/{id:guid}")]
        public async Task<ActionResult> Update(UpdateCommand command)
        {
            await this.mediator.SendAsync(command);

            return this.RedirectToActionJson("Index");
        }
    }
}