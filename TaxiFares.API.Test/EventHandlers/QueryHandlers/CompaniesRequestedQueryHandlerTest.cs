using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiFares.API.EventHandlers.QueryHandlers.Queries;
using TaxiFares.API.Infrastructure.ViewModels;
using TaxiFares.API.Test.ClassLibrary.AbstractTests;
using TaxiFares.API.Test.ClassLibrary.Models;

namespace TaxiFares.API.Test.EventHandlers.QueryHandlers
{
    [TestClass]
    public class CompaniesRequestedQueryHandlerTest : 
        TestWithCityUpdate
    {
        private readonly CompanyInputVM companyForTest;

        public CompaniesRequestedQueryHandlerTest() =>
            companyForTest = new CompanyInputVMForTest();

        [TestMethod]
        public async Task Handle_GivenQuery_ReturnsCompanies_Async()
        {
            IMediator mediator = 
                await UseSvcAsync<IMediator, IMediator>(
                    mediator => PublishCityUpdatedCmdAsync(mediator, 
                            companyForTest), false);
            IEnumerable<CompanyOutputVM> companies = await mediator
                .Send(new CompaniesRequestedQuery(companyForTest
                        .CityName));
            Assert.IsTrue(companies.Any());
            SvcScope.Dispose();
        }
    }
}
