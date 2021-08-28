using MediatR;
using System.Collections.Generic;
using TaxiFares.API.Infrastructure.ViewModels;

namespace TaxiFares.API.EventHandlers.QueryHandlers.Queries
{
    public class CompaniesRequested :
        IRequest<IEnumerable<CompanyViewModel>>
    {
    }
}
