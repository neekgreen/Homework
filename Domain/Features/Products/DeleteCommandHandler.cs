namespace Domain.Features.Products
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Models;
    using MediatR;

    public class DeleteCommandHandler : IAsyncRequestHandler<DeleteCommand, int>
    {
        private readonly IAppDbContext context;

        public DeleteCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }

        Task<int> IAsyncRequestHandler<DeleteCommand, int>.Handle(DeleteCommand message)
        {
            return Task.FromResult(HandleInternal(message));
        }

        private int HandleInternal(DeleteCommand message)
        {
            var product =
                this.context.Products
                    .Single(t=> t.Id == message.Id);

            product.MarkAsDeleted();

            return 0;
        }
    }
}