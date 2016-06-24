namespace Domain.Conventions
{
    using System;
    using System.Linq;
    using Domain.DependencyResolution;
    using StructureMap;

    public class TestContainerFactory
    {
        private static readonly Lazy<InnerFactory> lazyInnerFactory = new Lazy<InnerFactory>(() => new InnerFactory());

        public static IContainer Container
        {
            get { return lazyInnerFactory.Value.Container; }
        }

        private class InnerFactory
        {
            public InnerFactory()
            {
                Container = IoC.Initialize();
            }

            public IContainer Container { get; private set; }
        }
    }
}