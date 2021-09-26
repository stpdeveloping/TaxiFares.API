using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiFares.API.Infrastructure.ViewModels;
using TaxiFares.API.Infrastructure.ViewModels.CompanyViewModelChildren;

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
