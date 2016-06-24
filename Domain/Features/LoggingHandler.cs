namespace Domain.Features
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using MediatR;
    using Serilog;

    public class LoggingHandler<TRequest, TResponse> : IAsyncRequestHandler<TRequest, TResponse> where TRequest : IAsyncRequest<TResponse>
    {
        private readonly IAsyncRequestHandler<TRequest, TResponse> innerHandler;

        public LoggingHandler(IAsyncRequestHandler<TRequest, TResponse> innerHandler)
        {
            this.innerHandler = innerHandler;
        }

        Task<TResponse> IAsyncRequestHandler<TRequest, TResponse>.Handle(TRequest message)
        {
            Task<TResponse> result;
            var logger = Log.Logger.ForContext<TRequest>();

            using(logger.BeginTimedOperation("Handle Request"))
            {
                try
                {
                    result = this.innerHandler.Handle(message);
                    //logger.Information("Request Completed. {@Response}", result);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Error occurred [exception]", ex);
                    throw ex;
                }
                return result;
            }
        }
    }
}