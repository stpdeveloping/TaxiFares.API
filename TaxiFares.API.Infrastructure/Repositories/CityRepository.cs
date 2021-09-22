using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using TaxiFares.API.Domain.Aggregates.CityAggregate;
using TaxiFares.API.Domain.Common.Interfaces;

namespace TaxiFares.API.Infrastructure.Repositories
{
    public class CityRepository : Repository<City, string>,
        IRepository<City, string>
    {
        public CityRepository(Context context) : base(context)
        {
        }

        public override async IAsyncEnumerable<City> GetAllAsync(
            [EnumeratorCancellation] CancellationToken cToken)
        {
            IAsyncEnumerable<City> citiesAsyncEnumerable =
                Context.Cities.Include(city => city.Companies)
                .ThenInclude(company => company.Fares)
                .AsAsyncEnumerable();
            await foreach (City city in citiesAsyncEnumerable)
                yield return city;
        }
    }
}
