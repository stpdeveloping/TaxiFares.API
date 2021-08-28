using System.ComponentModel.DataAnnotations;
using TaxiFares.API.Domain.Common;
using TaxiFares.API.Domain.Exceptions;

namespace TaxiFares.API.Domain.Aggregates.CompanyAggregate
{
    public class Company : Entity, IAggregateRoot
    {
        [Required]
        public readonly string Name;
        [Required]
        public readonly string City;

        public virtual Fares Fares { get; private set; }

        public Company()
        {
        }

        public Company(int id, string name, string city)
        {
            Id = id;
            Name = name;
            City = city;
        }

        public override bool Equals(object obj)
        {
            if (obj is Company otherCompany)
                return Name == otherCompany.Name &&
                    City == otherCompany.City;
            else return false;
        }

        public override int GetHashCode() =>
            (Name, City).GetHashCode();

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new MissingCompanyDataException(nameof(Name));
            if (string.IsNullOrEmpty(City))
                throw new MissingCompanyDataException(nameof(City));
            if (Fares == null)
                throw new MissingCompanyDataException(nameof(Fares));
        }

        public void UpdateFares(double I, double II, double III,
            double IV) => Fares = new Fares(I, II, III, IV);
    }
}
