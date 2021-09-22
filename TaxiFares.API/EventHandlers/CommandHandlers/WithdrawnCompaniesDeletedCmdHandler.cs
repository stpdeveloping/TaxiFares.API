using System;
using System.Threading;
using System.Threading.Tasks;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;
using TaxiFares.API.Domain.Common.Interfaces;
using TaxiFares.API.EventHandlers.CommandHandlers.Abstract;
using TaxiFares.API.EventHandlers.CommandHandlers.Commands;

namespace TaxiFares.API.EventHandlers.CommandHandlers
{
    public class WithdrawnCompaniesDeletedCmdHandler :
        CompanyModifiedCommandHandler<WithdrawnCompaniesDeletedCmd>
    {
        public WithdrawnCompaniesDeletedCmdHandler(
            IRepository<Company, int> companyRepo) : base(companyRepo)
        {
        }

        public override async Task Handle(
            WithdrawnCompaniesDeletedCmd notification,
            CancellationToken cancellationToken)
        {
            await CompanyRepo.RemoveRangeAsync(company =>
                    company.ChangeDate <= DateTime.Now.AddMonths(-1),
                cancellationToken);
            await CompanyRepo.SaveChangesAsync(cancellationToken);
        }
    }
}
