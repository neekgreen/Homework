namespace Domain.Features.Products
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.Models;
    using MediatR;

    public class CreateCommandHandler : IAsyncRequestHandler<CreateCommand, Summary>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public CreateCommandHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        Task<Summary> IAsyncRequestHandler<CreateCommand, Summary>.Handle(CreateCommand message)
        {
            return Task.FromResult(HandleInternal(message));
        }

        private Summary HandleInternal(CreateCommand message)
        {
            var product =
                this.context.Products.Add(
                    new Product(message.CommonName, message.UnitPrice));

            var productSummary =
                this.mapper.Map<Summary>(product);

            return productSummary;
        }
    }
}