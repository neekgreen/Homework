namespace Domain.Features.Products
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using FluentAssertions;
    using MediatR;

    public class ListQueryTests
    {
        private readonly IMediator mediator;

        public ListQueryTests(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task ShouldHaveElements()
        {
            var query = new ListQuery { PageNumber = 1, ItemCountPerPage = 1 };
            var sut = await this.mediator.SendAsync(query);

            sut.Should().NotBeEmpty();
        }
    }
}