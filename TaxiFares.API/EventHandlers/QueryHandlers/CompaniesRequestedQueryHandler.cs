using AutoMapper;
using MediatR;
using System.Collections.Generic;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;
using TaxiFares.API.Domain.Common;
using TaxiFares.API.EventHandlers.QueryHandlers.Queries;
using TaxiFares.API.Infrastructure.ViewModels;

namespace TaxiFares.API.EventHandlers.QueryHandlers
{
    public class CompaniesRequestedQueryHandler :
        RequestHandler<CompaniesRequested,
            IEnumerable<CompanyViewModel>>
    {
        private readonly IRepository<Company> companyRepository;
        private readonly IMapper mapper;

        public CompaniesRequestedQueryHandler(
            IRepository<Company> companyRepository, IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }

        protected override IEnumerable<CompanyViewModel> Handle(
            CompaniesRequested request)
        {
            IEnumerable<Company> companies = companyRepository
                .GetAll();
            IEnumerable<CompanyViewModel> mappedCompanies =
                mapper.Map<IEnumerable<CompanyViewModel>>(companies);
            return mappedCompanies;
        }
    }
}
