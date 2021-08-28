using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;
using TaxiFares.API.Domain.Common;
using TaxiFares.API.EventHandlers.CommandHandlers.Commands;

namespace TaxiFares.API.EventHandlers.CommandHandlers
{
    public class CompanyUpdatedCommandHandler :
        INotificationHandler<CompanyUpdatedCommand>
    {
        private readonly IRepository<Company> companyRepository;
        private readonly IMapper mapper;

        public CompanyUpdatedCommandHandler(
            IRepository<Company> companyRepository, IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }

        public async Task Handle(CompanyUpdatedCommand command,
            CancellationToken cancellationToken)
        {
            var mappedCompany = mapper.Map<Company>(command
                .CompanyViewModel);
            await companyRepository.AddOrUpdateAsync(mappedCompany);
            await companyRepository.SaveChangesAsync();
        }
    }
}
