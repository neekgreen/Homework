namespace WebHost.Conventions
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using StructureMap;
    using StructureMap.Graph;
    using StructureMap.Graph.Scanning;
    using StructureMap.Pipeline;
    using StructureMap.TypeRules;

    public class ControllerConvention : IRegistrationConvention
    {
        void IRegistrationConvention.ScanTypes(TypeSet types, Registry registry)
        {
            types.AllTypes()
                .Where(type => type.CanBeCastTo<Controller>() && !type.IsAbstract)
                .ToList()
                .ForEach(type =>
                {
                    registry.For(type).LifecycleIs(new UniquePerRequestLifecycle());
                });
        }
    }
}