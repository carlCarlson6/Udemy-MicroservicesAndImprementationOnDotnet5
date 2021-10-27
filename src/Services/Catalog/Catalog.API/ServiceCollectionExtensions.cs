using Catalog.API.Data;
using Catalog.API.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.API
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
    }
}