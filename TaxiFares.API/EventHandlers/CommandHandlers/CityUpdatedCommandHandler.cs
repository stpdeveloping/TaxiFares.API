using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaxiFares.API.Domain.Aggregates.CityAggregate;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;
using TaxiFares.API.Domain.Common.Interfaces;
using TaxiFares.API.EventHandlers.CommandHandlers.Commands;
using TaxiFares.API.Extensions;
using TaxiFares.API.Infrastructure.ViewModels;
using TaxiFares.API.Infrastructure.ViewModels.CompanyViewModelChildren;

namespace TaxiFares.API.EventHandlers.CommandHandlers
{
    public class CityUpdatedCommandHandler :
        INotificationHandler<CityUpdatedCommand>
    {
        private readonly IRepository<City, string> cityRepo;
        private readonly IMediator mediator;

        private CompanyInputVM companyInputVM;
        private City existingCity;

        public CityUpdatedCommandHandler(
            IRepository<City, string> cityRepo, IMediator mediator)
        {
            this.cityRepo = cityRepo;
            this.mediator = mediator;
        }

        public async Task Handle(CityUpdatedCommand command,
            CancellationToken cancellationToken)
        {
            companyInputVM = command.CompanyInputVM;
            existingCity = await cityRepo.GetAsync(
                companyInputVM.CityName, cancellationToken);
            if (existingCity == null)
                await AddCity(cancellationToken);
            await PublishCompanyAddedOrUpdatedCommand();
        }

        private async Task AddCity(CancellationToken cancellationToken)
        {
            existingCity = new City(companyInputVM.CityName);
            cityRepo.Add(existingCity);
            await cityRepo.SaveChangesAsync(cancellationToken);
        }

        private async Task PublishCompanyAddedOrUpdatedCommand()
        {
            Company existingCompany = existingCity.Companies
                .GetByName(companyInputVM.Name);
            FaresViewModel faresVM = companyInputVM.FaresViewModel;
            if (existingCompany == null)
                await mediator.Publish(new CompanyAddedCommand(
                        existingCity.Id, companyInputVM.Name,
                        faresVM));
            else
                await mediator.Publish(new CompanyUpdatedCommand(
                        existingCompany, faresVM));
        }
    }
}
