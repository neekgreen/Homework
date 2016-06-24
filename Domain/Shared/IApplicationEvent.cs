namespace Domain.Shared
{
    using System;
    using System.Linq;

    public interface IApplicationEvent
    {
        string EventCommonName { get; }
    }
}