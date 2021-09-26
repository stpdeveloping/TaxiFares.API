using TaxiFares.API.Infrastructure.ViewModels.CompanyViewModelChildren;

namespace TaxiFares.API.Test.ClassLibrary.Models
{
    public class FaresViewModelForTest : FaresViewModel
    {
        public const double TestI = 4.99;
        public const double TestII = 5.99;
        public const double TestIII = 6.99;
        public const double TestIV = 7.99;

        public FaresViewModelForTest()
        {
            I = TestI;
            II = TestII;
            III = TestIII;
            IV = TestIV;
        }
    }
}
