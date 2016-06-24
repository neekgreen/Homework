namespace Domain.Shared
{
    using System;
    using System.Linq;

    public interface IDeletable
    {
        bool IsDeleted { get; }

        void MarkAsDeleted();
    }
}
