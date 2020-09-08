using IExpress.Core.DomainObjects;
using System;

namespace IExpress.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }

    }
}
