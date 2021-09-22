using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiFares.API.Domain.Aggregates.CityAggregate;
using TaxiFares.API.Infrastructure.EntityTypeConfigurations.Interfaces;

namespace TaxiFares.API.Infrastructure.EntityTypeConfigurations
{
    //[RegisterAs(typeof(ICityConfiguration), ServiceLifetime.Scoped)]
    public class CityConfiguration : ICityConfiguration
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasIndex(city => city.Id);
        }
    }
}
