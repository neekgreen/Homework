namespace WebHost.DependencyResolution
{
    using System;
    using System.Linq;
    using StructureMap;

    public class TransientNestedContainerScope : INestedContainerScope
    {
        public IContainer NestedContainer { get; set; }
    }
}