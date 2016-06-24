namespace Domain.Shared
{
    using System;
    using System.Linq;

    public interface IArchivable
    {
        bool IsArchived { get; }
    }
}