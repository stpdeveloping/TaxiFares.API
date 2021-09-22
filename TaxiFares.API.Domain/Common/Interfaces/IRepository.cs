using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TaxiFares.API.Domain.Common.Interfaces
{
    public interface IRepository<TEntity, TId> where
        TEntity : Entity<TId>, IAggregateRoot
    {
        /// <summary>
        /// This method's implementation is using 
        /// <c>GetAllAsync(CancellationToken cancellationToken)</c>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// <typeparamref name="ValueTask"/> with database entity
        /// </returns>
        ValueTask<TEntity> GetAsync(TId id,
            CancellationToken cancellationToken);
        void Add(TEntity entity);
        void Update(TEntity entity);
        /// <summary>
        /// If you want to make this method usable for entities with 
        /// nested entities, you should override it's implementation 
        /// in Repository class
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// <typeparamref name="IAsyncEnumerable"/> with database 
        /// entities
        /// </returns>
        IAsyncEnumerable<TEntity> GetAllAsync(
            CancellationToken cancellationToken);
        /// <summary>
        /// This method's implementation is using 
        /// <c>GetAllAsync(CancellationToken cancellationToken)</c> 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cToken"></param>
        /// <returns></returns>
        ValueTask RemoveRangeAsync(Func<TEntity, bool> predicate,
            CancellationToken cToken);
        ValueTask SaveChangesAsync(
            CancellationToken cancellationToken);
    }
}
