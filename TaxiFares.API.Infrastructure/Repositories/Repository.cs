using System;
using System.Collections.Generic;
using System.Linq;
using TaxiFares.API.Domain.Common;
using TaxiFares.API.Domain.Common.Interfaces;

namespace TaxiFares.API.Infrastructure.Repositories
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : Entity<TId>, IAggregateRoot
    {
        protected readonly Context Context;

        public Repository(Context context) => Context = context;

        public TEntity Get(TId id) => GetAll().SingleOrDefault(
                entity => entity.Id.Equals(id));

        public void Add(TEntity entity) => Context.Add(entity);

        public virtual void Update(TEntity entity) =>
            Context.Update(entity);

        public virtual IEnumerable<TEntity> GetAll() => 
            Context.Set<TEntity>();

        public void RemoveRange(Func<TEntity, bool> predicate)
        {
            IEnumerable<TEntity> selectedEntities = GetAll()
                .Where(predicate);
            Context.Set<TEntity>().RemoveRange(selectedEntities);
        }

        public void SaveChanges() => Context.SaveChanges();
    }
}
