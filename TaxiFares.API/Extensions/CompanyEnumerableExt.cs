using System.Collections.Generic;
using System.Linq;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;

namespace TaxiFares.API.Extensions
{
    public static class CompanyEnumerableExt
    {
        public static Company GetByName(
            this IEnumerable<Company> companies, string name) =>
            companies.SingleOrDefault(company => company.Name == name);
    }
}
