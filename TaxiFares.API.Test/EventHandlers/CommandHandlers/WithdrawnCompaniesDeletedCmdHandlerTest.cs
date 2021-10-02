using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiFares.API.EventHandlers.CommandHandlers.Commands;
using TaxiFares.API.EventHandlers.QueryHandlers.Queries;
using TaxiFares.API.Infrastructure;
using TaxiFares.API.Infrastructure.ViewModels;
using TaxiFares.API.Test.ClassLibrary.AbstractTests;
using TaxiFares.API.Test.ClassLibrary.Extensions;
using TaxiFares.API.Test.ClassLibrary.Models;

namespace TaxiFares.API.Test.EventHandlers.CommandHandlers
{
    [TestClass]
    public class WithdrawnCompaniesDeletedCmdHandlerTest : 
        TestWithDIAndDbContext<Context>
    {
        private readonly CompanyInputVM companyForTest;

        private IMediator mediator;
        private IEnumerable<CompanyOutputVM> companies;

        public WithdrawnCompaniesDeletedCmdHandlerTest() =>
            companyForTest = new TestCompanyInputVM();

        [TestMethod]
        public async Task Handle_GivenCommand_DeletesCompanyModifiedTwoMonthsAgo_Async()
        {
            mediator = await UseSvcWithDbContextAsync<IMediator, 
                    IMediator>((mediator, context) => 
                            CleanWithdrawnCompaniesAsync(mediator, 
                                context, monthsAgoChanged: 2),
                            false);
            await AssertThatCompanyIsDeletedAsync();
        }

        [TestMethod]
        public async Task Handle_GivenCommand_DeletesCompanyModifiedMonthAgo_Async()
        {
            mediator = await UseSvcWithDbContextAsync<IMediator,
                    IMediator>((mediator, context) =>
                            CleanWithdrawnCompaniesAsync(mediator,
                                context, monthsAgoChanged: 1),
                            false);
            await AssertThatCompanyIsDeletedAsync();
        }

        [TestMethod]
        public async Task Handle_GivenCommand_DeletesNothing_Async()
        {
            mediator = await UseSvcWithDbContextAsync<IMediator,
                    IMediator>((mediator, context) =>
                            CleanWithdrawnCompaniesAsync(mediator,
                                context, monthsAgoChanged: 0),
                            false);
            companies = await mediator.Send(
                new CompaniesRequestedQuery(companyForTest.CityName));
            Assert.IsTrue(companies.Any());
            SvcScope.Dispose();
        }

        private static async Task<IMediator> 
            CleanWithdrawnCompaniesAsync(IMediator mediator, 
            Context context, int monthsAgoChanged)
        {
            context.AddCompanyWithChangeDateMonthsBack(
                monthsAgoChanged);
            await mediator.Publish(new WithdrawnCompaniesDeletedCmd());
            return mediator;
        }

        private async Task AssertThatCompanyIsDeletedAsync()
        {
            companies = await mediator.Send(
                new CompaniesRequestedQuery(companyForTest.CityName));
            Assert.IsFalse(companies.Any());
            SvcScope.Dispose();
        }            
    }
}
