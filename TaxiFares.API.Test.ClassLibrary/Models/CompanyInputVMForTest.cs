using TaxiFares.API.Infrastructure.ViewModels;

namespace TaxiFares.API.Test.ClassLibrary.Models
{
    public class CompanyInputVMForTest : CompanyInputVM
    {
        public const string TestName = "SuperTaxi";
        public const string TestCityName = "Katowice";

        public CompanyInputVMForTest()
        {
            Name = TestName;
            CityName = TestCityName;
            FaresViewModel = new FaresViewModelForTest();
        }
    }
}
