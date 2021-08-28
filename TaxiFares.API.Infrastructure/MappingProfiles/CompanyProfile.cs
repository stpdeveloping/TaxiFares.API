using AutoMapper;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;
using TaxiFares.API.Infrastructure.ViewModels;
using TaxiFares.API.Infrastructure.ViewModels.CompanyViewModelChildren;

namespace TaxiFares.API.Infrastructure.MappingProfiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyViewModel>().ConstructUsing(
                company => MapCompanyToViewModel(company));
            CreateMap<CompanyViewModel, Company>().ConstructUsing(
                companyViewModel =>
                    MapCompanyViewModelToDomain(companyViewModel));
        }

        private static CompanyViewModel MapCompanyToViewModel(
            Company company)
        {
            FaresViewModel faresViewModel =
                MapFaresToViewModel(company.Fares);
            return new CompanyViewModel
            {
                Id = company.Id,
                Name = company.Name,
                City = company.City,
                FaresViewModel = faresViewModel
            };
        }

        private static FaresViewModel MapFaresToViewModel(
            Fares fares) => new FaresViewModel
            {
                I = fares.I,
                II = fares.II,
                III = fares.III,
                IV = fares.IV
            };

        private static Company MapCompanyViewModelToDomain(
            CompanyViewModel companyViewModel)
        {
            var domainCompany = new Company(companyViewModel.Id,
                companyViewModel.Name, companyViewModel.City);
            FaresViewModel faresViewModel =
                companyViewModel.FaresViewModel;
            domainCompany.UpdateFares(faresViewModel.I,
                faresViewModel.II, faresViewModel.III,
                faresViewModel.IV);
            return domainCompany;
        }
    }
}
