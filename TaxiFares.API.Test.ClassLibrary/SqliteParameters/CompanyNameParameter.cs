using Microsoft.Data.Sqlite;
using TaxiFares.API.Infrastructure.ViewModels;
using TaxiFares.API.Test.ClassLibrary.Models;

namespace TaxiFares.API.Test.ClassLibrary.SqliteParameters
{
    public class CompanyNameParameter : SqliteParameter
    {
        public CompanyNameParameter() : base(
                nameof(CompanyInputVM.Name), 
                TestCompanyInputVM.TestName)
        {
        }
    }
}
