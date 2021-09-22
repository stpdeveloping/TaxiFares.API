using MediatR;
using System.Collections.Generic;
using TaxiFares.API.Infrastructure.ViewModels;

namespace TaxiFares.API.EventHandlers.QueryHandlers.Queries
{
    public class CompaniesRequested :
        IRequest<IEnumerable<CompanyOutputVM>>
    {
        public readonly string cityName;

        public CompaniesRequested(string cityName) =>
            this.cityName = cityName;
    }
}
