namespace Domain.DependencyResolution
{
    using System;
    using System.Linq;
    using StructureMap;

    public interface INestedContainerScope
    {
        IContainer NestedContainer { get; set; }
    }
}