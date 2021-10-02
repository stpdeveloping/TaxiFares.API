using Microsoft.Data.Sqlite;
using System;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;
using TaxiFares.API.Test.ClassLibrary.SqliteParameters.Abstract;

namespace TaxiFares.API.Test.ClassLibrary.SqliteParameters
{
    public class CompanyChangeDateParam : SqliteDatetimeParameter
    {
        public CompanyChangeDateParam(int changeDateMonthsBack) : 
            base(nameof(Company.ChangeDate), DateTime.Now.AddMonths(
                -changeDateMonthsBack))
        {
        }
    }
}
