using Microsoft.Data.Sqlite;
using TaxiFares.API.Infrastructure.ViewModels;
using TaxiFares.API.Test.ClassLibrary.Models;

namespace TaxiFares.API.Test.ClassLibrary.SqliteParameters
{
    public class CompanyCityNameParam : SqliteParameter
    {
        public CompanyCityNameParam() : base(
            nameof(CompanyInputVM.CityName), 
            TestCompanyInputVM.TestCityName)
        {
        }
    }
}
