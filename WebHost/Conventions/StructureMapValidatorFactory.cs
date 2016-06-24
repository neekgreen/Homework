namespace WebHost.Conventions
{
    using System;
    using System.Linq;
    using FluentValidation;
    using StructureMap;
    using System.Web.Mvc;
    //using Microsoft.Practices.ServiceLocation;

    public class StructureMapValidatorFactory : ValidatorFactoryBase
    {
        //private readonly IContainer container;

        //public StructureMapValidatorFactory(IContainer container)
        //{
        //    this.container = container;
        //}

        public override IValidator CreateInstance(Type validatorType)
        {
            return DependencyResolver.Current.GetService(validatorType) as IValidator;
            //return ServiceLocator.Current.GetInstance(validatorType) as IValidator;
            //return container.TryGetInstance(validatorType) as IValidator;
        }
    }
}