namespace Domain.Conventions
{
    public class FixturePerMethodConvention : TestConvention
    {
        public FixturePerMethodConvention()
        {
            Classes
                .ConstructorDoesntHaveArguments();

            ClassExecution
                .CreateInstancePerCase();               
        }
    }
}