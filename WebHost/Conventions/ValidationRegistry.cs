namespace WebHost.Conventions
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Domain.Shared;
    using FluentValidation;
    using FluentValidation.Mvc;
    using StructureMap;
    using StructureMap.Graph;

    public class ValidationRegistry : Registry
    {
        public ValidationRegistry()
        {
            Scan(scan =>
            {
                scan.AssemblyContainingType<IEntity>();
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });

            For<ModelValidatorProvider>().Use<FluentValidationModelValidatorProvider>();
            For<IValidatorFactory>().Use<StructureMapValidatorFactory>();
        }
    }
}