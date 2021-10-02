using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;
using TaxiFares.API.Infrastructure;
using TaxiFares.API.Infrastructure.Extensions;
using TaxiFares.API.Infrastructure.ViewModels.CompanyViewModelChildren;
using TaxiFares.API.Test.ClassLibrary.SqliteParameters;

namespace TaxiFares.API.Test.ClassLibrary.Extensions
{
    public static class ContextExtension
    {
        public static void AddCompanyWithChangeDateMonthsBack(
            this Context context, int changeDateMonthsBack)
        {
            string sqlScript = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream(
                    Sql.AddCompanyWithChangeDateScript).ReadToEnd();
            context.Database.ExecuteSqlRaw(sqlScript, 
                GetSqlTestParams(changeDateMonthsBack));
        }

        private static IEnumerable<SqliteParameter> GetSqlTestParams(
            int changeDateMonthsBack) => new List<SqliteParameter> 
            {
                new CompanyCityNameParam(), new CompanyChangeDateParam(
                    changeDateMonthsBack), new CompanyNameParameter(), 
                new FaresFareParameter(nameof(FaresViewModel.I)),
                new FaresFareParameter(nameof(FaresViewModel.II)),
                new FaresFareParameter(nameof(FaresViewModel.III)),
                new FaresFareParameter(nameof(FaresViewModel.IV))
            };
    }
}
