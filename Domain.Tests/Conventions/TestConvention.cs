namespace Domain.Conventions
{
    using System;
    using System.Linq;
    using Ploeh.AutoFixture;

    public abstract class TestConvention : FixieConvention
    {
        public TestConvention()
        {
            Classes
                .AreInTestNamespace();
        }

        protected override ICustomization AutoFixtureCustomization
        {
            get { return new TestFixtureCustomization(); }
        }
    }
}