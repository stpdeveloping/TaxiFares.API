using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public override IEnumerable<City> GetAll() => Context.Cities
            .Include(city => city.Companies).ThenInclude(company => 
                    company.Fares);        
    }
}
