using TaxiFares.API.Domain.Common;

namespace TaxiFares.API.Domain.Aggregates.CompanyAggregate
{
    public class Fares : Entity<int>
    {
        public double I { get; private set; }
        public double II { get; private set; }
        public double III { get; private set; }
        public double IV { get; private set; }

        public readonly int CompanyId;
        public virtual Company Company { get; }

        public void Set(double I, double II, double III, double IV)
        {
            this.I = I;
            this.II = II;
            this.III = III;
            this.IV = IV;
        }

        public override bool Equals(object obj) =>
            obj is Fares otherFares && I == otherFares.I &&
            II == otherFares.II && III == otherFares.III &&
            IV == otherFares.IV;

        public override int GetHashCode() => (I, II, III, IV)
            .GetHashCode();
    }
}
