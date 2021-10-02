using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaxiFares.API.Domain.Aggregates.CityAggregate;
using TaxiFares.API.Domain.Common.Interfaces;
using TaxiFares.API.EventHandlers.QueryHandlers.Queries;
using TaxiFares.API.Infrastructure.ViewModels;

namespace TaxiFares.API.EventHandlers.QueryHandlers
{
    public class CompaniesRequestedQueryHandler
        :
        IRequestHandler<CompaniesRequestedQuery,
            IEnumerable<CompanyOutputVM>>
    {
        private readonly IRepository<City, string> cityRepo;
        private readonly IMapper mapper;

        public CompaniesRequestedQueryHandler(
            IRepository<City, string> cityRepository, IMapper mapper)
        {
            cityRepo = cityRepository;
            this.mapper = mapper;
        }

        public Task<IEnumerable<CompanyOutputVM>> Handle(
            CompaniesRequestedQuery query, CancellationToken _)
        {
            City city = cityRepo.Get(query.cityName);
            return Task.FromResult(mapper
                .Map<IEnumerable<CompanyOutputVM>>(city?.Companies));
        }
    }
}
