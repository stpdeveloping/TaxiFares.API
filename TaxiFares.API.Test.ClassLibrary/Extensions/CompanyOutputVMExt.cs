using TaxiFares.API.Infrastructure.ViewModels;
using TaxiFares.API.Infrastructure.ViewModels.CompanyViewModelChildren;

namespace TaxiFares.API.Test.ClassLibrary.Extensions
{
    public static class CompanyOutputVMExt
    {
        public static bool EqualsCompanyInputVM(
            this CompanyOutputVM companyOutputVM,
            CompanyInputVM companyInputVM)
        {
            FaresViewModel outputFaresVM = companyOutputVM
                .FaresViewModel;
            FaresViewModel inputFaresVM = companyInputVM
                .FaresViewModel;
            return companyOutputVM.Name == companyInputVM.Name &&
                outputFaresVM.I == inputFaresVM.I &&
                outputFaresVM.II == inputFaresVM.II &&
                outputFaresVM.III == inputFaresVM.III && 
                outputFaresVM.IV == inputFaresVM.IV;
        }
    }
}
