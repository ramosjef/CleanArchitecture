using System;

namespace CleanArchitecture.Domain.Core.Interfaces
{
    public interface IRepository<TEntity> :
        IAdd<TEntity>,
        IRemove<TEntity>,
        IUpdate<TEntity>,
        IGetAll<TEntity>,
        IGetId<TEntity>,
        IFind<TEntity>,
        IDisposable where TEntity : class
    {
    }
}
