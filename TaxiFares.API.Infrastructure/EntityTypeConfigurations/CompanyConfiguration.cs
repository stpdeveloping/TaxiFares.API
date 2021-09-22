using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;
using TaxiFares.API.Infrastructure.EntityTypeConfigurations.Interfaces;

namespace TaxiFares.API.Infrastructure.EntityTypeConfigurations
{
    //[RegisterAs(typeof(ICompanyConfiguration), ServiceLifetime.Scoped)]
    public class CompanyConfiguration : ICompanyConfiguration
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(company => company.Name).IsRequired();
            builder.Property(company => company.ChangeDate)
                .HasDefaultValueSql(SqlFunctionNames.GetCurrentDate);
            builder.HasOne(company => company.City).WithMany(
                city => city.Companies).HasForeignKey(
                company => company.CityId).IsRequired();
        }
    }
}
