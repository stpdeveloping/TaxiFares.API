using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaxiFares.API.Domain.Common
{
    public interface IRepository<TEntity> where
        TEntity : IAggregateRoot
    {
        ValueTask AddOrUpdateAsync(TEntity detachedEntity);
        IEnumerable<TEntity> GetAll();
        ValueTask SaveChangesAsync();
    }
}
