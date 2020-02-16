using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CleanArchitecture.Domain.Core.Entities;
using CleanArchitecture.Domain.Core.Interfaces;

namespace CleanArchitecture.Infrastructure.MongoDbDataAccess.Repositories
{
    public class Repository<TEntity> :
        IRepository<TEntity> where TEntity : EntityBase
    {
        protected IMongoCollection<TEntity> _collection;

        public Repository(Context context, string collectionName)
        {
            _collection = context.GetCollection<TEntity>(collectionName);
        }

        public Guid Add(TEntity entity)
        {
            _collection.InsertOne(entity);
            return entity.Id;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _collection = null;
        }

        public IEnumerable<TEntity> Find(
            Expression<Func<TEntity, bool>> predicate)
        {
            return _collection.AsQueryable().Where(predicate);
        }

        public IPaged<TEntity> Find(
            Expression<Func<TEntity, bool>> predicate, int? page, int? count)
        {
            var items = _collection.AsQueryable()
                ?.OrderBy(p => p.Id)
                ?.Where(predicate.Compile());

            var paged = new Paged<TEntity>
            {
                TotalItemsCount = items?.Count() ?? 0,
                Page = page ?? 0,
                PageCount = count ?? int.MaxValue
            };

            paged.Items = items
                ?.Skip(paged.Page * paged.PageCount)
                ?.Take(paged.PageCount);

            return paged;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _collection.AsQueryable();
        }

        public TEntity GetId(Guid key)
        {
            var entity = _collection.AsQueryable()
                ?.Where(c => c.Id.Equals(key))
                ?.FirstOrDefault();

            return entity;
        }

        public bool Remove(TEntity entity)
        {
            var response = _collection.DeleteOne(c => c.Id.Equals(entity.Id));
            return response.DeletedCount > 0;
        }

        public bool Update(TEntity entity)
        {
            var res = _collection.ReplaceOne(c => c.Id.Equals(entity.Id), entity);
            return res.ModifiedCount > 0;
        }
    }
}
