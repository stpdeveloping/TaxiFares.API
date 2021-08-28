using System.Threading.Tasks;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;

namespace TaxiFares.API.Infrastructure
{
    public class CompanyRepository : Repository<Company>
    {
        private Company existingCompany;

        public CompanyRepository(Context context) : base(context)
        {
        }

        public override async ValueTask AddOrUpdateAsync(
            Company detachedCompanyEntity)
        {
            detachedCompanyEntity.Validate();
            existingCompany = await Context.FindAsync<Company>(
                detachedCompanyEntity.Id);
            if (existingCompany == null)
                Context.Add(detachedCompanyEntity);
            else UpdateCompanyIfItsChanged(detachedCompanyEntity);
        }

        private void UpdateCompanyIfItsChanged(
            Company detachedCompanyEntity)
        {
            if (!existingCompany.Equals(detachedCompanyEntity))
                Context.Entry(existingCompany).CurrentValues
                .SetValues(detachedCompanyEntity);
            detachedCompanyEntity.Fares.SetId(existingCompany.Fares
                .Id);
            UpdateFaresIfItsChanged(detachedCompanyEntity.Fares);
        }

        private void UpdateFaresIfItsChanged(
            Fares detachedFaresEntity)
        {
            Fares existingCompanyFares = existingCompany.Fares;
            if (!existingCompanyFares.Equals(detachedFaresEntity))
                Context.Entry(existingCompanyFares).CurrentValues
                .SetValues(detachedFaresEntity);
        }
    }
}
