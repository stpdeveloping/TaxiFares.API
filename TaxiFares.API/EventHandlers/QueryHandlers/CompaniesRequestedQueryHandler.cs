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

        public async Task<IEnumerable<CompanyOutputVM>>
            Handle(CompaniesRequestedQuery query,
                CancellationToken cancellationToken)
        {
            City city = await cityRepo.GetAsync(query.cityName,
                cancellationToken);
            return mapper.Map<IEnumerable<CompanyOutputVM>>(
                city?.Companies);
        }
    }
}
