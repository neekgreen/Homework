namespace WebHost.DependencyResolution
{
    using System;
    using System.Web;
    //using StructureMap.Web.Pipeline;

    public class StructureMapScopeModule : IHttpModule
    {
        public void Dispose() { }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, e) => StructureMapConfiguration.ParentScope.CreateNestedContainer();
            context.EndRequest += (sender, e) =>
            {
                //HttpContextLifecycle.DisposeAndClearAll();
                StructureMapConfiguration.ParentScope.DisposeNestedContainer();
            };
        }
    }
}