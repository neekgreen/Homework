namespace Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FluentAssertions;
    using MediatR;

    public class ProductTests
    {
        private readonly Product product;

        public ProductTests(Product product)
        {
            this.product = product;
        }

        public void ShouldUpdateCommonName()
        {
            var commonName = "something";
            product.Update(commonName, 50.0M);

            product.CommonName.ShouldBeEquivalentTo("ab");
        }

        public void ShouldUpdateUnitPrice()
        {
            var unitPrice = 45.0M;
            product.Update("some product", unitPrice);

            product.UnitPrice.ShouldBeEquivalentTo(unitPrice);
        }

        public void ShouldHaveProductUpdatedDomainEvent()
        {
            product.Update("some product", 10M);
            product.Events.OfType<ProductUpdated>().Any().ShouldBeEquivalentTo(true);
        }
    }
}