using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiFares.API.EventHandlers.CommandHandlers.Commands;
using TaxiFares.API.EventHandlers.QueryHandlers.Queries;
using TaxiFares.API.Infrastructure.ViewModels;

namespace TaxiFares.API.Controllers
{
    [Route(Routes.Api)]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CompaniesController(IMediator mediator) =>
            this.mediator = mediator;

        [HttpGet(Routes.Companies)]
        public async ValueTask<IEnumerable<CompanyOutputVM>>
            GetCompanies(string cityName) => await mediator.Send(
                new CompaniesRequested(cityName));

        [HttpPut(Routes.Company)]
        public async ValueTask UpdateCompany(
            CompanyInputVM company) => await mediator.Publish(
                new CityUpdatedCommand(company));
    }
}
