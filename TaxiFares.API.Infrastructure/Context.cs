using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;
using TaxiFares.API.Infrastructure.ConfigurationOptions;
using TaxiFares.API.Infrastructure.EntityTypeConfigurations;

namespace TaxiFares.API.Infrastructure
{
    public class Context : DbContext
    {
        private readonly string connString;
        private readonly ICompanyConfiguration companyConfiguration;
        private readonly IFaresConfiguration faresConfiguration;

        public DbSet<Company> Companies { get; set; }

        public Context(IOptions<DataAccess> dataAccessOptions,
            ICompanyConfiguration companyConfiguration,
            IFaresConfiguration faresConfiguration)
        {
            connString = dataAccessOptions.Value.ConnectionString;
            this.companyConfiguration = companyConfiguration;
            this.faresConfiguration = faresConfiguration;
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder options)
        {
            options.UseLazyLoadingProxies();
            options.UseSqlite(connString);
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(companyConfiguration);
            modelBuilder.ApplyConfiguration(faresConfiguration);
        }
    }
}
