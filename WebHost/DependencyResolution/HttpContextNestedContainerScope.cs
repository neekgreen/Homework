namespace WebHost.DependencyResolution
{
    using System.Web;
    using StructureMap;

    public class HttpContextNestedContainerScope : INestedContainerScope
    {
        private const string NestedContainerKey = "Nested.Container.Key";

        public IContainer NestedContainer
        {
            get
            {
                return (IContainer)(HttpContext.Current != null ? HttpContext.Current.Items[NestedContainerKey] : null);
            }
            set
            {
                HttpContext.Current.Items[NestedContainerKey] = value;
            }
        }
    }
}