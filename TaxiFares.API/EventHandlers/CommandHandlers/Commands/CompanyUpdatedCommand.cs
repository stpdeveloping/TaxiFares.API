using TaxiFares.API.Domain.Aggregates.CompanyAggregate;
using TaxiFares.API.EventHandlers.CommandHandlers.Commands.Abstract;
using TaxiFares.API.Infrastructure.ViewModels.CompanyViewModelChildren;

namespace TaxiFares.API.EventHandlers.CommandHandlers.Commands
{
    public class CompanyUpdatedCommand : CompanyAddedOrUpdatedCommand
    {
        public readonly Company ExistingCompany;

        public CompanyUpdatedCommand(Company existingCompany,
            FaresViewModel faresViewModel) : base(faresViewModel) =>
            ExistingCompany = existingCompany;
    }
}
