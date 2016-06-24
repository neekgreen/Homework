namespace Domain.Features
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using MediatR;
    using Serilog;
    using Domain.Models;


    public class TransactionPipeline<TRequest, TResponse> : IAsyncRequestHandler<TRequest, TResponse> where TRequest : IAsyncRequest<TResponse>
    {
        private readonly IAsyncRequestHandler<TRequest, TResponse> innerRequestHandler;
        private readonly IAppDbContext context;

        public TransactionPipeline(IAsyncRequestHandler<TRequest, TResponse> innerRequestHandler, IAppDbContext context)
        {
            this.innerRequestHandler = innerRequestHandler;
            this.context = context;
        }

        Task<TResponse> IAsyncRequestHandler<TRequest, TResponse>.Handle(TRequest message)
        {
            var logger = Log.Logger.ForContext<TRequest>();

            Task<TResponse> response;
            try
            {
                this.context.BeginTransaction();
                response = this.innerRequestHandler.Handle(message);
                this.context.CloseTransaction();
            }
            catch (Exception ex)
            {
                logger.Error(ex, string.Empty);
                throw;
            }
            return response;
        }
    }
}