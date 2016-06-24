namespace Domain.Conventions
{
    using System;
    using System.Linq;
    using Ploeh.AutoFixture;
    using Domain.DependencyResolution;

    public class TestFixtureCustomization : AutoFixtureCustomization
    {
        protected override void CustomizeFixture(IFixture fixture)
        {
            var scope = new StructureMapDependencyScope(TestContainerFactory.Container);

            //fixture.Register<IAuditable>(() => new Auditable());

            fixture.Customizations.Add(new ContainerBuilder(scope)); // always last
        }
    }
}