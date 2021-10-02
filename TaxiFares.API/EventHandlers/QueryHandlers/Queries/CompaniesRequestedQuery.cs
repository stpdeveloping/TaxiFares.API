using MediatR;
using System.Collections.Generic;
using TaxiFares.API.Infrastructure.ViewModels;

namespace TaxiFares.API.EventHandlers.QueryHandlers.Queries
{
    public class CompaniesRequestedQuery :
        IRequest<IEnumerable<CompanyOutputVM>>
    {
        public readonly string cityName;

        public CompaniesRequestedQuery(string cityName) =>
            this.cityName = cityName;
    }
}
