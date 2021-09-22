using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TaxiFares.API.Domain.Aggregates.CityAggregate;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;
using TaxiFares.API.Infrastructure.ConfigurationOptions;
using TaxiFares.API.Infrastructure.EntityTypeConfigurations.Interfaces;

namespace TaxiFares.API.Infrastructure
{
    public class Context : DbContext
    {
        private readonly string connString;
        private readonly ICityConfiguration cityConfiguration;
        private readonly ICompanyConfiguration companyConfiguration;
        private readonly IFaresConfiguration faresConfiguration;

        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }

        public Context(IOptions<DataAccess> dataAccessOptions,
            ICityConfiguration cityConfiguration,
            ICompanyConfiguration companyConfiguration,
            IFaresConfiguration faresConfiguration)
        {
            connString = dataAccessOptions.Value.ConnectionString;
            this.cityConfiguration = cityConfiguration;
            this.companyConfiguration = companyConfiguration;
            this.faresConfiguration = faresConfiguration;
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder options) =>
            options.UseSqlite(connString);

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(cityConfiguration);
            modelBuilder.ApplyConfiguration(companyConfiguration);
            modelBuilder.ApplyConfiguration(faresConfiguration);
        }
    }
}
