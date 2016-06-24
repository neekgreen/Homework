namespace WebHost.DependencyResolution
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Domain.Shared;
    using StructureMap;
    using StructureMap.Graph;
    using WebHost.Conventions;

    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(scan =>
            {
                scan.AssemblyContainingType<IEntity>();
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();

                scan.With(new ControllerConvention());
                scan.LookForRegistries();

                scan.AddAllTypesOf(typeof(IModelBinder));
                scan.AddAllTypesOf(typeof(IModelBinderProvider));
            });
        }
    }
}