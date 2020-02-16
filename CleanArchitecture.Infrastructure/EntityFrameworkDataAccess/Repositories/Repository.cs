using CleanArchitecture.Domain.Core.Entities;
using CleanArchitecture.Domain.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.EntityFrameworkDataAccess.Repositories
{
    public class Repository<TEntity>
        : IRepository<TEntity> where TEntity : EntityBase
    {
        protected DbSet<TEntity> Db;

        public Repository(Context context)
        {
            Db = context.Set<TEntity>();
        }

        public Guid Add(TEntity entity)
        {
            Db.Add(entity);
            return entity.Id;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
            Db = null;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Db
                .AsNoTracking()
                .Where(predicate.Compile());
        }

        public IPaged<TEntity> Find(Expression<Func<TEntity, bool>> predicate, int? page, int? count)
        {
            var items = Db
                ?.AsNoTracking()
                ?.OrderBy(p => p.Id)
                ?.Where(predicate.Compile());

            var paged = new Paged<TEntity>
            {
                TotalItemsCount = items?.Count() ?? 0,
                Page = page ?? 0,
                PageCount = count ?? int.MaxValue
            };

            paged.Items = Db
                ?.Skip(paged.Page * paged.PageCount)
                ?.Take(paged.PageCount);

            return paged;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.AsNoTracking();
        }

        public TEntity GetId(Guid key)
        {
            return Db
                ?.AsNoTracking()
                ?.Where(c => c.Id.Equals(key))
                ?.FirstOrDefault();
        }

        public bool Remove(TEntity entity)
        {
            var res = Db.Remove(entity);
            return res.State == EntityState.Deleted;
        }

        public bool Update(TEntity entity)
        {
            var res = Db.Update(entity);
            return res.State == EntityState.Modified;
        }
    }
}
