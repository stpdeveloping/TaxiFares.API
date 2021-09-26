using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;
using TaxiFares.API.Infrastructure;
using TaxiFares.API.Infrastructure.Extensions;
using TaxiFares.API.Infrastructure.ViewModels;
using TaxiFares.API.Infrastructure.ViewModels.CompanyViewModelChildren;
using TaxiFares.API.Test.ClassLibrary.Models;

namespace TaxiFares.API.Test.ClassLibrary.Extensions
{
    public static class ContextExtension
    {
        public static void AddCompanyWithChangeDateMonthsBack(
            this Context context, int changeDateMonthsBack)
        {
            string sqlScript = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream(SqlFileForTestNames
                    .AddCompanyWithChangeDateForTest)
                .ReadToEnd();
            context.Database.ExecuteSqlRaw(sqlScript, 
                GetSqlTestParams(changeDateMonthsBack));
        }

        private static IEnumerable<SqliteParameter> GetSqlTestParams(
            int changeDateMonthsBack) => new List<SqliteParameter> 
            {
                new SqliteParameter($"@{nameof(CompanyInputVM.CityName)}", 
                    CompanyInputVMForTest.TestCityName), 
                    new SqliteParameter($"@{nameof(Company.ChangeDate)}", 
                        $"{DateTime.Now.AddMonths(-changeDateMonthsBack):yyyy-MM-dd HH:00:00}"),
                    new SqliteParameter($"@{nameof(CompanyInputVM.Name)}", 
                        CompanyInputVMForTest.TestName),
                    new SqliteParameter($"@{nameof(FaresViewModel.I)}",
                        FaresViewModelForTest.TestI), 
                    new SqliteParameter($"@{nameof(FaresViewModel.II)}",
                        FaresViewModelForTest.TestII), 
                    new SqliteParameter($"@{nameof(FaresViewModel.III)}",
                        FaresViewModelForTest.TestIII), 
                    new SqliteParameter($"@{nameof(FaresViewModel.IV)}",
                        FaresViewModelForTest.TestIV)
            };
    }
}
