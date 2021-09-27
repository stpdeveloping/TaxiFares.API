using System;
using TaxiFares.API.Domain.Aggregates.CityAggregate;
using TaxiFares.API.Domain.Common;
using TaxiFares.API.Domain.Common.Interfaces;
using TaxiFares.API.Domain.Exceptions;

namespace TaxiFares.API.Domain.Aggregates.CompanyAggregate
{
    public class Company : Entity<int>, IAggregateRoot
    {
        public readonly string Name;
        public DateTime ChangeDate { get; }

        public virtual Fares Fares { get; private set; }
        public readonly string CityId;
        public virtual City City { get; }

        public Company()
        {
        }

        public Company(string name, Fares fares, string cityId)
        {
            Name = !string.IsNullOrEmpty(name) ? name :
                throw new MissingCompanyDataException(nameof(name));
            Fares = fares ?? throw new MissingCompanyDataException(
                    nameof(fares));
            CityId = cityId;
        }

        public void UpdateFares(Fares fares)
        {
            if (fares != null)
                Fares.Set(fares.I, fares.II, fares.III, fares.IV);
            else
                throw new MissingCityDataException(nameof(Fares));
        }
    }
}
