namespace Domain.Features.Carts
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.Models;
    using MediatR;

    public class UpdateCommandHandler : IAsyncRequestHandler<UpdateCommand, Summary>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public UpdateCommandHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        Task<Summary> IAsyncRequestHandler<UpdateCommand, Summary>.Handle(UpdateCommand message)
        {
            return Task.FromResult(HandleInternal(message));
        }

        private Summary HandleInternal(UpdateCommand message)
        {
            var cart =
                this.context.Carts
                    .Where(t => t.Id == message.Id)
                    .FirstOrDefault();

            var product =
                this.context.Products
                    .Where(t => t.Id == message.ProductId)
                    .Single();

            cart.Include(product, message.Quantity);

            var result = this.mapper.Map<Summary>(cart);

            return result;
        }
    }
}