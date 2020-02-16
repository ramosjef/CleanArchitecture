using System;

namespace CleanArchitecture.Domain.Core.Interfaces
{
    public interface IAdd<TEntity>
    {
        Guid Add(TEntity entity);
    }
}
