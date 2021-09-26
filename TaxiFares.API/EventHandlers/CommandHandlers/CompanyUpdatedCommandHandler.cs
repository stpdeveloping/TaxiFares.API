using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;
using TaxiFares.API.Domain.Common.Interfaces;
using TaxiFares.API.EventHandlers.CommandHandlers.Abstract;
using TaxiFares.API.EventHandlers.CommandHandlers.Commands;

namespace TaxiFares.API.EventHandlers.CommandHandlers
{
    public class CompanyUpdatedCommandHandler :
        CompanyAddedOrUpdatedCmdHandler<CompanyUpdatedCommand>
    {
        public CompanyUpdatedCommandHandler(
            IRepository<Company, int> companyRepo, IMapper mapper) :
            base(companyRepo, mapper)
        {
        }

        public override async Task Handle(
            CompanyUpdatedCommand command,
            CancellationToken cancellationToken)
        {
            Company existingCompany = command.ExistingCompany;
            var inputFares = mapper.Map<Fares>(command.FaresViewModel);
            if (!existingCompany.Fares.Equals(inputFares))
            {
                existingCompany.UpdateFares(inputFares);
                CompanyRepo.Update(existingCompany);
                await CompanyRepo.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
