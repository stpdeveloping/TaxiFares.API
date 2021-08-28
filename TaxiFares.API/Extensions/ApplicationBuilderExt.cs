using Microsoft.AspNetCore.Builder;

namespace TaxiFares.API.Extensions
{
    public static class ApplicationBuilderExt
    {
        public static void UseSwagger(
            this IApplicationBuilder applicationBuilder,
            string apiName)
        {
            applicationBuilder.UseSwagger();
            applicationBuilder.UseSwaggerUI(options =>
                options.SwaggerEndpoint(Routes.Swagger, apiName));
        }
    }
}
