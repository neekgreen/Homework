namespace Domain.Features
{
    using System;
    using System.Linq;
    using FluentValidation;
    using MediatR;
    using StructureMap;
    using StructureMap.Graph;

    public class FeatureRegistry : Registry
    {
        public FeatureRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.AssemblyContainingType<IMediator>();

                scan.WithDefaultConventions();

                scan.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                scan.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>));
                scan.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                scan.ConnectImplementationsToTypesClosing(typeof(IAsyncNotificationHandler<>));

                scan.AddAllTypesOf(typeof(IValidator<>));

                var handlerType = For(typeof(IAsyncRequestHandler<,>));

                handlerType.DecorateAllWith(typeof(LoggingHandler<,>));
                handlerType.DecorateAllWith(typeof(TransactionPipeline<,>), (t) => t.ReturnedType.Name.EndsWith("CommandHandler"));
                handlerType.DecorateAllWith(typeof(RequestValidationHandler<,>));

                For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
                For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));

                For<IMediator>().Use<Mediator>();
            });
        }
    }





    public class Command : IRequest<int>
    {

    }

    public class CommandHandler : IRequestHandler<Command, int>
    {

        public int Handle(Command message)
        {
            throw new NotImplementedException();
        }
    }



}