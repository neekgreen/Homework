namespace Domain.Features.Products
{
    using System;
    using System.Linq;
    using FluentValidation;

    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(t => t.Id).NotEmpty();
            RuleFor(t => t.CommonName).NotEmpty().Length(4, 50);
            RuleFor(t => t.UnitPrice).GreaterThanOrEqualTo(0);
        }
    }
}