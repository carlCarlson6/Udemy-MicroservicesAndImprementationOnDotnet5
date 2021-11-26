using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Discount.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) => services;

        public static IServiceCollection AddApiDocumentation(this IServiceCollection services) =>
            services.AddSwaggerGen(c =>
                c.SwaggerDoc(
                    "v1", new OpenApiInfo { Title = "Catalog.API", Version = "v1" }));
    }
}