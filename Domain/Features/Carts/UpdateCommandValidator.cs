namespace Domain.Features.Carts
{
    using System;
    using System.Linq;
    using FluentValidation;

    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(t => t.Quantity).GreaterThanOrEqualTo(1);;
        }
    }
}