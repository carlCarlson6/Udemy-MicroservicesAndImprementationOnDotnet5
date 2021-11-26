using System;
using Catalog.API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Catalog.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void ConfigureDevelopmentApp(this WebApplication webApp)
        {
            webApp
                .UseSwagger()
                .UseSwaggerUI(c =>
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API v1"));
        }

        public static void SeedData(this WebApplication webApplication)
        {
            var optionConfig = webApplication.Services.GetService<IOptions<MongoDbConfiguration>>() ?? 
                                 throw new Exception(nameof(IOptions<MongoDbConfiguration>));
            var catalogContext = new CatalogContext(optionConfig);
            CatalogContextSeed.SeedData(catalogContext.Products);
        }
    }
}