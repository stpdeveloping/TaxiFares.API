using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using TaxiFares.API.EventHandlers.CommandHandlers.Commands;

namespace TaxiFares.API.HostedServices
{
    public class WithdrawnCompaniesCleaner : BackgroundService
    {
        private readonly IServiceProvider svcProvider;

        public WithdrawnCompaniesCleaner(
            IServiceProvider serviceProvider) =>
            svcProvider = serviceProvider;

        protected override async Task ExecuteAsync(
            CancellationToken cToken)
        {
            while (!cToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromDays(14), cToken);
                await PublishWithdrawnCompaniesDeletedCmd(cToken);
            }
        }

        private async ValueTask PublishWithdrawnCompaniesDeletedCmd(
            CancellationToken cToken)
        {
            using IServiceScope scope = svcProvider.CreateScope();
            await scope.ServiceProvider
                .GetRequiredService<IMediator>()
                .Publish(new WithdrawnCompaniesDeletedCmd(), cToken);
        }
    }
}
