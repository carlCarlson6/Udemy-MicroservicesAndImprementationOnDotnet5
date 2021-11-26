using Catalog.API.Data;
using Catalog.API.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Catalog.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoContexts(this IServiceCollection services, ConfigurationManager configuration)
        {
            var mongoDbConfigurationSection = configuration.GetSection(nameof(MongoDbConfiguration));
            return services
                .Configure<MongoDbConfiguration>(mongoDbConfigurationSection)
                .AddScoped<ICatalogContext, CatalogContext>();
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services.AddScoped<IProductRepository, ProductRepository>();

        public static IServiceCollection AddApiDocumentation(this IServiceCollection services) =>
            services.AddSwaggerGen(c =>
                c.SwaggerDoc(
                    "v1", new OpenApiInfo { Title = "Catalog.API", Version = "v1" }));
    }
}