using WebHost.DependencyResolution;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(StructureMapConfiguration), "Start")]
[assembly: ApplicationShutdownMethod(typeof(StructureMapConfiguration), "End")]

namespace WebHost.DependencyResolution
{
    using System;
    using System.Web.Mvc;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using StructureMap;

    public static class StructureMapConfiguration
    {
        public static StructureMapDependencyScope ParentScope { get; set; }

        public static void End()
        {
            ParentScope.Dispose();
            ParentScope.DisposeParentContainer();
        }

        public static void Start()
        {
            IContainer container = IoC.Initialize();

            //# Note: This will not work with Azure.
            ParentScope = new StructureMapDependencyScope(container, new HttpContextNestedContainerScope());

            DependencyResolver.SetResolver(ParentScope);

            //# Add our scope management module to the ASPNET pipeline.
            DynamicModuleUtility.RegisterModule(typeof(StructureMapScopeModule));
        }
    }
}