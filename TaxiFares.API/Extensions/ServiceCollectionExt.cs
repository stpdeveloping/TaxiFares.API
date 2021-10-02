using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxiFares.API.Domain.Aggregates.CityAggregate;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;
using TaxiFares.API.Domain.Common.Interfaces;
using TaxiFares.API.Infrastructure;
using TaxiFares.API.Infrastructure.ConfigurationOptions;
using TaxiFares.API.Infrastructure.EntityTypeConfigurations;
using TaxiFares.API.Infrastructure.EntityTypeConfigurations.Interfaces;
using TaxiFares.API.Infrastructure.Repositories;

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
            services.AddDbContext<Context>();
            services.AddEntityConfigurations();
            services.AddRepositories();
        }

        public static void AddEntityConfigurations(
            this IServiceCollection services)
        {
            services.AddScoped<ICompanyConfiguration,
                CompanyConfiguration>();
            services.AddScoped<IFaresConfiguration,
                FaresConfiguration>();
            services.AddScoped<ICityConfiguration,
                CityConfiguration>();
        }

        private static void AddRepositories(
            this IServiceCollection services)
        {
            services.AddScoped<IRepository<City, string>,
                CityRepository>();
            services.AddScoped<IRepository<Company, int>,
                CompanyRepository>();
        }
    }
}
