namespace Domain.Subscribers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Models;
    using MediatR;

    public class OrderSubmittedEmail : IAsyncNotificationHandler<OrderSubmitted>
    {
        private readonly IAppDbContext context;

        public OrderSubmittedEmail(IAppDbContext context)
        {
            this.context = context;
        }

        Task IAsyncNotificationHandler<OrderSubmitted>.Handle(OrderSubmitted notification)
        {
            //# Send email here or create a record to send email later via microservice.
            return Task.FromResult(0);
        }
    }
}