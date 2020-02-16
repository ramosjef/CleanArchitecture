using System.Collections.Generic;

namespace CleanArchitecture.Domain.Core.Interfaces
{
    public interface IGetAll<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
    }
}
