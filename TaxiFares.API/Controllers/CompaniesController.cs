using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiFares.API.EventHandlers.CommandHandlers.Commands;
using TaxiFares.API.EventHandlers.QueryHandlers.Queries;
using TaxiFares.API.Infrastructure.ViewModels;

namespace TaxiFares.API.Controllers
{
    [Route("api")]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CompaniesController(IMediator mediator) =>
            this.mediator = mediator;

        [HttpGet(Routes.Companies)]
        public async ValueTask<IEnumerable<CompanyViewModel>>
            GetCompanies() => await mediator.Send(
                new CompaniesRequested());

        [HttpPut(Routes.Company)]
        public async ValueTask UpdateCompany(
            CompanyViewModel company) => await mediator.Publish(
                new CompanyUpdatedCommand(company));
    }
}
