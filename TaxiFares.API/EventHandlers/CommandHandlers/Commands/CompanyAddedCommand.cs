using TaxiFares.API.EventHandlers.CommandHandlers.Commands.Abstract;
using TaxiFares.API.Infrastructure.ViewModels.CompanyViewModelChildren;

namespace TaxiFares.API.EventHandlers.CommandHandlers.Commands
{
    public class CompanyAddedCommand : CompanyAddedOrUpdatedCommand
    {
        public readonly string CityId;
        public readonly string CompanyName;

        public CompanyAddedCommand(string cityId, string companyName,
            FaresViewModel faresViewModel) : base(faresViewModel)
        {
            CityId = cityId;
            CompanyName = companyName;
        }
    }
}
