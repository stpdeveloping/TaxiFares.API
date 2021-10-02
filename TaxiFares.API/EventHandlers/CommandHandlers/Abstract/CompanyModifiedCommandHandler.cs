using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;
using TaxiFares.API.Domain.Common.Interfaces;
using TaxiFares.API.EventHandlers.CommandHandlers.Commands.Interfaces;

namespace TaxiFares.API.EventHandlers.CommandHandlers.Abstract
{
    public abstract class CompanyModifiedCommandHandler<TCommand> :
        INotificationHandler<TCommand>
        where TCommand : ICompanyModifiedCommand
    {
        protected readonly IRepository<Company, int> CompanyRepo;

        public CompanyModifiedCommandHandler(
            IRepository<Company, int> companyRepository) =>
            CompanyRepo = companyRepository;

        public abstract Task Handle(TCommand command,
            CancellationToken cancellationToken);
    }
}
