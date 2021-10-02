using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using TaxiFares.API.Domain.Aggregates.CityAggregate;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;
using TaxiFares.API.Infrastructure.ConfigurationOptions;
using TaxiFares.API.Infrastructure.EntityTypeConfigurations.Interfaces;
using TaxiFares.API.Infrastructure.Extensions;

namespace TaxiFares.API.Infrastructure
{
    public class Context : DbContext
    {
        private readonly IOptions<DataAccess> dataAccessOptions;
        private readonly ICityConfiguration cityConfiguration;
        private readonly ICompanyConfiguration companyConfiguration;
        private readonly IFaresConfiguration faresConfiguration;
        private readonly IHostEnvironment hostEnv;

        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }

        public Context(IOptions<DataAccess> dataAccessOptions,
            ICityConfiguration cityConfiguration,
            ICompanyConfiguration companyConfiguration,
            IFaresConfiguration faresConfiguration,
            IHostEnvironment hostEnv)
        {
            this.dataAccessOptions = dataAccessOptions;
            this.cityConfiguration = cityConfiguration;
            this.companyConfiguration = companyConfiguration;
            this.faresConfiguration = faresConfiguration;
            this.hostEnv = hostEnv;
            if (this.hostEnv.IsEnvironment(EnvironmentNames.Test))
                Database.InitSqliteDbInMemory();
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder options) =>
            options.UseSqlite(dataAccessOptions.Value
                .ConnectionString);

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(cityConfiguration);
            modelBuilder.ApplyConfiguration(companyConfiguration);
            modelBuilder.ApplyConfiguration(faresConfiguration);
        }
    }
}
