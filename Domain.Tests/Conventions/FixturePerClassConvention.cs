namespace Domain.Conventions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Kernel;


    public class FixturePerClassConvention : TestConvention
    {
        public FixturePerClassConvention()
        {
            Classes
                .ConstructorHasArguments();

            ClassExecution
                .CreateInstancePerClass();

            Parameters.Add(FillFromFixture);
        }

        private IEnumerable<object[]> FillFromFixture(MethodInfo method)
        {
            var fixture = new Fixture();

            yield return GetParameterData(method.GetParameters(), fixture);
        }

        private object[] GetParameterData(ParameterInfo[] parameters, Fixture fixture)
        {
            return parameters
                .Select(p => new SpecimenContext(fixture).Resolve(p.ParameterType))
                .ToArray();
        }
    }
}