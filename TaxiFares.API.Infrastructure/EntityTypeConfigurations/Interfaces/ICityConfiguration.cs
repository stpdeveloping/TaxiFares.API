using Microsoft.EntityFrameworkCore;
using TaxiFares.API.Domain.Aggregates.CityAggregate;

namespace TaxiFares.API.Infrastructure.EntityTypeConfigurations
    .Interfaces
{
    public interface ICityConfiguration :
        IEntityTypeConfiguration<City>
    {
    }
}
