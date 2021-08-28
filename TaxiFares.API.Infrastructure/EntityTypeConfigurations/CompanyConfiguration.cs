using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;

namespace TaxiFares.API.Infrastructure.EntityTypeConfigurations
{
    public class CompanyConfiguration : ICompanyConfiguration
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(company => company.Name);
            builder.Property(company => company.City);
        }
    }
}
