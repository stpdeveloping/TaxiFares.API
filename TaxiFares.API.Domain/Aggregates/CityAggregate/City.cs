using System.Collections.Generic;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;
using TaxiFares.API.Domain.Common;
using TaxiFares.API.Domain.Common.Interfaces;
using TaxiFares.API.Domain.Exceptions;

namespace TaxiFares.API.Domain.Aggregates.CityAggregate
{
    public class City : Entity<string>, IAggregateRoot
    {
        private readonly IList<Company> companies;

        public virtual IEnumerable<Company> Companies
        {
            get => companies;
        }

        public City()
        {
        }

        public City(string name)
        {
            Id = !string.IsNullOrEmpty(name) ? name :
                throw new MissingCityDataException(nameof(name));
            companies = new List<Company>();
        }
    }
}
