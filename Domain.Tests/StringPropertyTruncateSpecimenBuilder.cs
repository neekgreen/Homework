using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;

namespace Domain
{
    public class StringPropertyTruncateSpecimenBuilder<T> : ISpecimenBuilder
    {
        private readonly int stringLength;
        private readonly PropertyInfo propertyInfo;

        public StringPropertyTruncateSpecimenBuilder(Expression<Func<T, string>> getExpression, int stringLength)
        {
            this.stringLength = stringLength;
            this.propertyInfo = (PropertyInfo)((MemberExpression)getExpression.Body).Member;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as PropertyInfo;

            return pi != null && AreEquivalent(pi, propertyInfo)
                ? context.Create<string>().Substring(0, stringLength)
                : (object)new NoSpecimen(request);
        }

        private bool AreEquivalent(PropertyInfo a, PropertyInfo b)
        {
            return a.DeclaringType == b.DeclaringType
                   && a.Name == b.Name;
        }
    }
}