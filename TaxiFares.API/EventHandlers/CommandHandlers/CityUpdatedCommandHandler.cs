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
            CancellationToken cToken)
        {
            companyInputVM = command.CompanyInputVM;
            existingCity = cityRepo.Get(companyInputVM.CityName);
            if (existingCity == null)
                AddCity();
            await PublishCompanyAddedOrUpdatedCommandAsync(cToken);
        }

        private void AddCity()
        {
            existingCity = new City(companyInputVM.CityName);
            cityRepo.Add(existingCity);
            cityRepo.SaveChanges();
        }

        private async Task PublishCompanyAddedOrUpdatedCommandAsync(
            CancellationToken cancellationToken)
        {
            Company existingCompany = existingCity.Companies
                .GetByName(companyInputVM.Name);
            FaresViewModel faresVM = companyInputVM.FaresViewModel;
            if (existingCompany == null)
                await mediator.Publish(new CompanyAddedCommand(
                        existingCity.Id, companyInputVM.Name,
                        faresVM), cancellationToken);
            else
                await mediator.Publish(new CompanyUpdatedCommand(
                        existingCompany, faresVM), cancellationToken);
        }
    }
}
