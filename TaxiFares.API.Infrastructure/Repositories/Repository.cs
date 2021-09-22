using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using TaxiFares.API.Domain.Common;
using TaxiFares.API.Domain.Common.Interfaces;

namespace TaxiFares.API.Infrastructure.Repositories
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : Entity<TId>, IAggregateRoot
    {
        protected readonly Context Context;

        public Repository(Context context) => Context = context;

        public async ValueTask<TEntity> GetAsync(TId id,
            CancellationToken cancellationToken) =>
            await GetAllAsync(cancellationToken).SingleOrDefaultAsync(
                entity => entity.Id.Equals(id), cancellationToken);

        public void Add(TEntity entity) => Context.Add(entity);

        public virtual void Update(TEntity entity) =>
            Context.Update(entity);

        public virtual async IAsyncEnumerable<TEntity> GetAllAsync(
            [EnumeratorCancellation] CancellationToken cToken)
        {
            await foreach (TEntity entity in Context.Set<TEntity>()
                .AsAsyncEnumerable())
                yield return entity;
        }

        public async ValueTask RemoveRangeAsync(
            Func<TEntity, bool> predicate, CancellationToken cToken)
        {
            TEntity[] selectedEntities = await GetAllAsync(cToken)
                .Where(predicate).ToArrayAsync(cToken);
            Context.Set<TEntity>().RemoveRange(selectedEntities);
        }

        public async ValueTask SaveChangesAsync(
            CancellationToken cancellationToken) =>
            await Context.SaveChangesAsync(cancellationToken);
    }
}
