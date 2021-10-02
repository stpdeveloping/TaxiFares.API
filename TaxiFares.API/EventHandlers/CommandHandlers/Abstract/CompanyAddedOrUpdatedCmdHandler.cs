using AutoMapper;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;
using TaxiFares.API.Domain.Common.Interfaces;
using TaxiFares.API.EventHandlers.CommandHandlers.Commands.Abstract;

namespace TaxiFares.API.EventHandlers.CommandHandlers.Abstract
{
    public abstract class CompanyAddedOrUpdatedCmdHandler<TCommand> :
        CompanyModifiedCommandHandler<TCommand>
        where TCommand : CompanyAddedOrUpdatedCommand
    {
        protected readonly IMapper mapper;

        public CompanyAddedOrUpdatedCmdHandler(
            IRepository<Company, int> companyRepo, IMapper mapper) :
            base(companyRepo) => this.mapper = mapper;
    }
}
