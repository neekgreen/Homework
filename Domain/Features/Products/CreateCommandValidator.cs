namespace Domain.Features.Products
{
    using System;
    using System.Linq;
    using FluentValidation;
using Domain.Models;

    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(t => t.CommonName).NotEmpty().Length(4, 50);
            RuleFor(t => t.UnitPrice).GreaterThanOrEqualTo(0);
        }
    }
}