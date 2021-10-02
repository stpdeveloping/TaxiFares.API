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
            CreateMap<Company, CompanyOutputVM>().ForMember(
                destination => destination.FaresViewModel, source =>
                    source.MapFrom(source => source.Fares));
            MapFaresAndFaresViewModel();
        }

        private void MapFaresAndFaresViewModel()
        {
            CreateMap<Fares, FaresViewModel>();
            CreateMap<FaresViewModel, Fares>();
        }
    }
}
