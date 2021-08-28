using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiFares.API.Domain.Common;

namespace TaxiFares.API.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity, IAggregateRoot
    {
        protected readonly Context Context;

        public Repository(Context context) => Context = context;

        public virtual async ValueTask AddOrUpdateAsync(
            TEntity detachedEntity)
        {
            detachedEntity.Validate();
            TEntity existingEntity =
                await Context.FindAsync<TEntity>(detachedEntity.Id);
            if (existingEntity == null)
                Context.Add(detachedEntity);
            else if (!existingEntity.Equals(detachedEntity))
                Context.Entry(existingEntity).CurrentValues
                    .SetValues(detachedEntity);
        }

        public IEnumerable<TEntity> GetAll() => Context.Set<TEntity>();

        public async ValueTask SaveChangesAsync() =>
            await Context.SaveChangesAsync();
    }
}
