using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaxiFares.API.Extensions;
using TaxiFares.API.Infrastructure;
using TaxiFares.API.Infrastructure.MappingProfiles;

[assembly: ApiController]
namespace TaxiFares.API
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment environment;

        public Startup(IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            this.configuration = configuration;
            this.environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(config =>
                config.AddProfile<CompanyProfile>());
            services.AddDbDependencies(configuration);
            if (environment.IsDevelopment())
                services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, Context context)
        {
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                string apiName = GetType().Assembly.GetName().Name;
                app.UseSwagger(apiName);
            }
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            context.Database.Migrate();
        }
    }
}
