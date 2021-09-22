using TaxiFares.API.EventHandlers.CommandHandlers.Commands.Interfaces;
using TaxiFares.API.Infrastructure.ViewModels.CompanyViewModelChildren;

namespace TaxiFares.API.EventHandlers.CommandHandlers.Commands.Abstract
{
    public abstract class CompanyAddedOrUpdatedCommand :
        ICompanyModifiedCommand
    {
        public readonly FaresViewModel FaresViewModel;

        public CompanyAddedOrUpdatedCommand(
            FaresViewModel faresViewModel) =>
            FaresViewModel = faresViewModel;
    }
}
