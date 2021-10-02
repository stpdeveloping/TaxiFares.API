using TaxiFares.API.Infrastructure.ViewModels;

namespace TaxiFares.API.Test.ClassLibrary.Models
{
    public class TestCompanyInputVM : CompanyInputVM
    {
        public const string TestName = "SuperTaxi";
        public const string TestCityName = "Katowice";

        public TestCompanyInputVM()
        {
            Name = TestName;
            CityName = TestCityName;
            FaresViewModel = new TestFaresVM();
        }
    }
}
