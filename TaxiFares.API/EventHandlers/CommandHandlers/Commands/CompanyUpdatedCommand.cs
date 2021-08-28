using MediatR;
using TaxiFares.API.Infrastructure.ViewModels;

namespace TaxiFares.API.EventHandlers.CommandHandlers.Commands
{
    public class CompanyUpdatedCommand : INotification
    {
        public readonly CompanyViewModel CompanyViewModel;

        public CompanyUpdatedCommand(
            CompanyViewModel companyViewModel) =>
            CompanyViewModel = companyViewModel;
    }
}
