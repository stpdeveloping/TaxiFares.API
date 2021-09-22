using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;
using TaxiFares.API.Infrastructure.EntityTypeConfigurations.Interfaces;

namespace TaxiFares.API.Infrastructure.EntityTypeConfigurations
{
    //[RegisterAs(typeof(IFaresConfiguration), ServiceLifetime.Scoped)]
    public class FaresConfiguration : IFaresConfiguration
    {
        public void Configure(EntityTypeBuilder<Fares> builder)
        {
            builder.Property(fares => fares.I);
            builder.Property(fares => fares.II);
            builder.Property(fares => fares.III);
            builder.Property(fares => fares.IV);
            builder.HasOne(fares => fares.Company).WithOne(
                company => company.Fares).HasForeignKey<Fares>(
                fares => fares.CompanyId).IsRequired();
        }
    }
}
