namespace Domain.DependencyResolution
{
    using System;
    using System.Linq;
    using Domain.Shared;
    using StructureMap;
    using StructureMap.Graph;

    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(scan =>
            {
                scan.AssemblyContainingType<IEntity>();
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();

                scan.LookForRegistries();
            });
        }
    }
}