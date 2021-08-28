using TaxiFares.API.Domain.Common;

namespace TaxiFares.API.Domain.Aggregates.CompanyAggregate
{
    public class Fares : Entity
    {
        public readonly double I;
        public readonly double II;
        public readonly double III;
        public readonly double IV;

        public Fares()
        {
        }

        public Fares(double I, double II, double III,
            double IV)
        {
            this.I = I;
            this.II = II;
            this.III = III;
            this.IV = IV;
        }

        public override bool Equals(object obj)
        {
            if (obj is Fares otherFares)
                return I == otherFares.I && II == otherFares.II &&
                    III == otherFares.III && IV == otherFares.IV;
            else return false;
        }

        public override int GetHashCode() => (I, II, III, IV)
            .GetHashCode();

        public void SetId(int id) => Id = id;
    }
}
