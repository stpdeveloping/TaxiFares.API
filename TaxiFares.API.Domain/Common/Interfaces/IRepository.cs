using System;
using System.Collections.Generic;

namespace TaxiFares.API.Domain.Common.Interfaces
{
    public interface IRepository<TEntity, TId> where
        TEntity : Entity<TId>, IAggregateRoot
    {
        /// <summary>
        /// This method's implementation is using <c>GetAll()</c>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Database <typeparamref name="TEntity"/>
        /// </returns>
        TEntity Get(TId id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        /// <summary>
        /// If you want to make this method usable for entities with 
        /// nested entities, you should override it's implementation 
        /// in Repository class
        /// </summary>
        /// <returns>
        /// <typeparamref name="IEnumerable"/> with database entities
        /// </returns>
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// This method's implementation is using <c>GetAll()</c>
        /// </summary>
        /// <param name="predicate"></param>
        void RemoveRange(Func<TEntity, bool> predicate);
        void SaveChanges();
    }
}
