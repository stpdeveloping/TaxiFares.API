using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiFares.API.EventHandlers.QueryHandlers.Queries;
using TaxiFares.API.Infrastructure.ViewModels;
using TaxiFares.API.Test.ClassLibrary.AbstractTests;
using TaxiFares.API.Test.ClassLibrary.Extensions;
using TaxiFares.API.Test.ClassLibrary.Models;

namespace TaxiFares.API.Test.EventHandlers.CommandHandlers
{
    [TestClass]
    public class CityUpdatedCmdHandlerTest : TestWithCityUpdate
    {
        private readonly CompanyInputVM companyForTest;

        public CityUpdatedCmdHandlerTest() =>
            companyForTest = new TestCompanyInputVM();

        [TestMethod]
        public async Task Handle_GivenCommand_AddsCompany_Async()
        {
            IMediator mediator =
                await UseSvcAsync<IMediator, IMediator>(
                    mediator => PublishCityUpdatedCmdAsync(mediator,
                            companyForTest), false);
            IEnumerable<CompanyOutputVM> companies = await mediator
                .Send(new CompaniesRequestedQuery(companyForTest
                        .CityName));
            Assert.IsNotNull(companies.SingleOrDefault(company =>
                        company.EqualsCompanyInputVM(companyForTest)));
            SvcScope.Dispose();
        }
    }
}
