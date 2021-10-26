using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Catalog.API
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
                c.SwaggerDoc(
                    "v1", 
                    new OpenApiInfo
                    {
                        Title = "Catalog.API", 
                        Version = "v1"
                    })
                );

            return services;
        }
    }
}