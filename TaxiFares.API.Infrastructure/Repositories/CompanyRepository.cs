using Microsoft.EntityFrameworkCore;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;
using TaxiFares.API.Domain.Common.Interfaces;

namespace TaxiFares.API.Infrastructure.Repositories
{
    public class CompanyRepository : Repository<Company, int>,
        IRepository<Company, int>
    {
        public CompanyRepository(Context context) : base(context)
        {
        }

        public override void Update(Company company) =>
            Context.Entry(company).State = EntityState.Unchanged;
    }
}
