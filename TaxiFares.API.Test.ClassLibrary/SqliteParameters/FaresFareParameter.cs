using Microsoft.Data.Sqlite;
using TaxiFares.API.Infrastructure.ViewModels.CompanyViewModelChildren;
using TaxiFares.API.Test.ClassLibrary.Exceptions;
using TaxiFares.API.Test.ClassLibrary.Models;

namespace TaxiFares.API.Test.ClassLibrary.SqliteParameters
{
    public class FaresFareParameter : SqliteParameter
    {
        public FaresFareParameter(string fareRomanNumber) : base(
                fareRomanNumber, GetTestValueForFare(fareRomanNumber))
        {
        }

        private static double GetTestValueForFare(
            string fareRomanNumber) => fareRomanNumber switch
            {
                nameof(FaresViewModel.I) => TestFaresVM.TestI,
                nameof(FaresViewModel.II) => TestFaresVM.TestII,
                nameof(FaresViewModel.III) => TestFaresVM.TestIII,
                nameof(FaresViewModel.IV) => TestFaresVM.TestIV,
                _ => throw new InvalidFareRomanNumberException(
                        fareRomanNumber)
            };
    }
}
