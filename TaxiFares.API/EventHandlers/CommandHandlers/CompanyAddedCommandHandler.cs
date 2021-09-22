using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;
using TaxiFares.API.Domain.Common.Interfaces;
using TaxiFares.API.EventHandlers.CommandHandlers.Abstract;
using TaxiFares.API.EventHandlers.CommandHandlers.Commands;

namespace TaxiFares.API.EventHandlers.CommandHandlers
{
    public class CompanyAddedCommandHandler :
        CompanyAddedOrUpdatedCmdHandler<CompanyAddedCommand>
    {
        public CompanyAddedCommandHandler(
            IRepository<Company, int> companyRepo, IMapper mapper) :
            base(companyRepo, mapper)
        {
        }

        public override async Task Handle(
            CompanyAddedCommand notification,
            CancellationToken cancellationToken)
        {
            var inputFares = mapper.Map<Fares>(
                notification.FaresViewModel);
            var newCompany = new Company(notification.CompanyName,
                inputFares, notification.CityId);
            CompanyRepo.Add(newCompany);
            await CompanyRepo.SaveChangesAsync(cancellationToken);
        }
    }
}
