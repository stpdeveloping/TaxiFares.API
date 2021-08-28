using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;

namespace TaxiFares.API.Infrastructure.EntityTypeConfigurations
{
    public class FaresConfiguration : IFaresConfiguration
    {
        public void Configure(EntityTypeBuilder<Fares> builder)
        {
            builder.Property(fares => fares.I);
            builder.Property(fares => fares.II);
            builder.Property(fares => fares.III);
            builder.Property(fares => fares.IV);
        }
    }
}
