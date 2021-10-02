using MediatR;
using System.Threading.Tasks;
using TaxiFares.API.EventHandlers.CommandHandlers.Commands;
using TaxiFares.API.Infrastructure.ViewModels;

namespace TaxiFares.API.Test.ClassLibrary.AbstractTests
{
    public abstract class TestWithCityUpdate : 
        TestWithDependencyInjection
    {
        protected static async Task<IMediator> 
            PublishCityUpdatedCmdAsync(IMediator mediator, 
            CompanyInputVM companyInputVM)
        {
            await mediator.Publish(new CityUpdatedCommand(
                    companyInputVM));
            return mediator;
        }
    }
}
