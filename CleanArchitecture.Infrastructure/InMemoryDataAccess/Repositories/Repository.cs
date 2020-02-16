using CleanArchitecture.Domain.Core.Entities;
using CleanArchitecture.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.InMemoryDataAccess.Repositories
{
    public class Repository<TEntity> :
        IRepository<TEntity> where TEntity : EntityBase
    {
        protected IQueryable<TEntity> Collection;

        public Repository()
        {
        }

        public Guid Add(TEntity entity)
        {
            Collection.ToList().Add(entity);
            return entity.Id;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Collection.Where(predicate);
        }

        public IPaged<TEntity> Find(Expression<Func<TEntity, bool>> predicate, int? page, int? count)
        {
            var paged = new Paged<TEntity>
            {
                TotalItemsCount = Collection.Count(),
                Page = page ?? 0,
                PageCount = count ?? int.MaxValue
            };

            paged.Items = Collection
                ?.OrderBy(p => p.Id)
                ?.Where(predicate.Compile())
                ?.Skip(paged.Page * paged.PageCount)
                ?.Take(paged.PageCount);

            return paged;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Collection;
        }

        public TEntity GetId(Guid key)
        {
            return Collection
                ?.Where(c => c.Id.Equals(key))
                ?.FirstOrDefault();
        }

        public bool Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public void Dispose() { }
    }
}
