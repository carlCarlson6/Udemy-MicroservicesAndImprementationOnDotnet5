using Basket.API.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Basket.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiDocumentation(this IServiceCollection services) =>
            services.AddSwaggerGen(c =>
                c.SwaggerDoc(
                    "v1", new OpenApiInfo { Title = "Catalog.API", Version = "v1" }));

        public static IServiceCollection AddRedis(this IServiceCollection services, ConfigurationManager configuration)
        {
            var connectionString = configuration.GetValue<string>("RedisCacheSettings:ConnectionString");
            return services.AddStackExchangeRedisCache(options =>
                options.Configuration = connectionString);
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services.AddScoped<IBasketRepository, RedisBasketRepository>();

        public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
            services;
    }
}