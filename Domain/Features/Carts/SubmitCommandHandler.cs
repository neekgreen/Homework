namespace Domain.Features.Carts
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.Models;
    using MediatR;

    public class SubmitCommandHandler : IAsyncRequestHandler<SubmitCommand, SubmitResult>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public SubmitCommandHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        Task<SubmitResult> IAsyncRequestHandler<SubmitCommand, SubmitResult>.Handle(SubmitCommand message)
        {
            return Task.FromResult(HandleInternal(message));
        }

        private SubmitResult HandleInternal(SubmitCommand message)
        {
            var orderNumber = 
                long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss")).ToString();

            var cart =
                this.context.Carts
                    .Include(t => t.CartItems)
                    .Include(t => t.CartItems.Select(u => u.Product))
                    .Single(t => t.Id == message.Id);

            var order =
                this.context.Orders.Add(
                    cart.Submit(orderNumber));

            //# cheating
            var cartItems = cart.CartItems.ToArray();

            cart.Clear();

            foreach(var cartItem in cartItems)
            {
                this.context.Set<CartItem>().Remove(cartItem);
            }

            var result =
                this.mapper.Map<SubmitResult>(order);

            return result;
        }
    }
}