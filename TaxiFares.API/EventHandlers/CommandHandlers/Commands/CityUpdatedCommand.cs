using MediatR;
using TaxiFares.API.Infrastructure.ViewModels;

namespace TaxiFares.API.EventHandlers.CommandHandlers.Commands
{
    public class CityUpdatedCommand : INotification
    {
        public readonly CompanyInputVM CompanyInputVM;

        public CityUpdatedCommand(CompanyInputVM companyInputVM) =>
            CompanyInputVM = companyInputVM;
    }
}
