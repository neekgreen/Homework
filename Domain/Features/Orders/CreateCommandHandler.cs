namespace Domain.Features.Orders
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.Models;
    using MediatR;

    public class CreateCommandHandler : IAsyncRequestHandler<CreateCommand, CreateResult>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public CreateCommandHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        Task<CreateResult> IAsyncRequestHandler<CreateCommand, CreateResult>.Handle(CreateCommand message)
        {
            return Task.FromResult(HandleInternal(message));
        }

        private CreateResult HandleInternal(CreateCommand message)
        {
            throw new NotImplementedException();
        }
    }
}