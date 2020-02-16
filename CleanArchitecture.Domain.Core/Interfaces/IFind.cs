using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CleanArchitecture.Domain.Core.Interfaces
{
    public interface IFind<TEntity>
    {
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IPaged<TEntity> Find(Expression<Func<TEntity, bool>> predicate, int? page, int? count);
    }
}
