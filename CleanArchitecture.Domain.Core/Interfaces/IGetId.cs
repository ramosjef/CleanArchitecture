using System;

namespace CleanArchitecture.Domain.Core.Interfaces
{
    public interface IGetId<TEntity>
    {
        TEntity GetId(Guid key);
    }
}
