namespace Domain.Features.Products
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Domain.Models;
    using MediatR;

    public class UpdateQueryHandler : IAsyncRequestHandler<UpdateQuery, UpdateCommand>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public UpdateQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        Task<UpdateCommand> IAsyncRequestHandler<UpdateQuery, UpdateCommand>.Handle(UpdateQuery message)
        {
            return Task.FromResult(HandleInternal(message));
        }

        private UpdateCommand HandleInternal(UpdateQuery message)
        {
            var result =
                context.Products
                    .Where(t => t.Id == message.Id)
                    .ProjectTo<UpdateCommand>(mapper.ConfigurationProvider)
                    .Single();

            return result;
        }
    }
}