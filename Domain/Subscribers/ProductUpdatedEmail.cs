namespace Domain.Subscribers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Models;
    using MediatR;

    public class ProductUpdatedEmail : IAsyncNotificationHandler<ProductUpdated>
    {
        public ProductUpdatedEmail()
        {

        }

        Task IAsyncNotificationHandler<ProductUpdated>.Handle(ProductUpdated notification)
        {
            //# Do some work.

            return Task.FromResult(0);
        }
    }
}