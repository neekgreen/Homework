namespace Domain.Features.Products
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
            var product =
                this.context.Products
                    .SingleOrDefault(t=> t.Id == message.Id);

            product.Update(message.CommonName, message.UnitPrice);

            var productSummary =
                this.mapper.Map<Summary>(product);

            return productSummary;
        }
    }
}