using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;
using TaxiFares.API.Domain.Common;
using TaxiFares.API.Infrastructure;
using TaxiFares.API.Infrastructure.ConfigurationOptions;
using TaxiFares.API.Infrastructure.EntityTypeConfigurations;

namespace TaxiFares.API.Extensions
{
    public static class ServiceCollectionExt
    {
        public static void AddDbDependencies(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<DataAccess>(configuration.GetSection(
                nameof(DataAccess)));
            services.AddScoped<ICompanyConfiguration,
                CompanyConfiguration>();
            services.AddScoped<IFaresConfiguration,
                FaresConfiguration>();
            services.AddDbContext<Context>();
            services.AddScoped<IRepository<Company>,
                CompanyRepository>();
        }
    }
}
