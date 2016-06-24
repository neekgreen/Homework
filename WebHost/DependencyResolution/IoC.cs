namespace WebHost.DependencyResolution
{
    using System;
    using System.Linq;
    using StructureMap;

    public static class IoC
    {
        public static IContainer Initialize()
        {
            return new Container(c => c.AddRegistry<DefaultRegistry>());
        }
    }
}