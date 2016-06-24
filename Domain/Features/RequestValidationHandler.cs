namespace Domain.Features
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using FluentValidation;
    using MediatR;

    public class RequestValidationHandler<TRequest, TResponse> : IAsyncRequestHandler<TRequest, TResponse> where TRequest : IAsyncRequest<TResponse>
    {
        private readonly IAsyncRequestHandler<TRequest, TResponse> innerHandler;
        private readonly IValidator<TRequest>[] validators;

        public RequestValidationHandler(IAsyncRequestHandler<TRequest, TResponse> innerHandler, IValidator<TRequest>[] validators)
        {
            this.innerHandler = innerHandler;
            this.validators = validators;
        }

        Task<TResponse> IAsyncRequestHandler<TRequest, TResponse>.Handle(TRequest message)
        {
            var context = new ValidationContext(message);

            var failures =
                this.validators
                    .Select(t => t.Validate(context))
                    .SelectMany(result => result.Errors)
                    .Where(t => t != null)
                    .ToList();

            if (failures.Any())
                throw new ValidationException(failures);

            return this.innerHandler.Handle(message);
        }
    }
}