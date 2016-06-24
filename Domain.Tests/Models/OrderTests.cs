namespace Domain.Models
{
    using System;
    using System.Linq;
    using FluentAssertions;

    public class OrderTests
    {
        public void ShouldDoSomething(Order order)
        {
            order.Events.OfType<OrderSubmitted>().Any().ShouldBeEquivalentTo(true);
        }
    }
}