using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Catalog.API
{
    public static class ApiConfigurations
    {
        public static void ConfigureServices(IServiceCollection services, ConfigurationManager configuration) =>
            services
                .AddMongoContexts(configuration)
                .AddRepositories()
                .AddSwaggerGen(c =>
                    c.SwaggerDoc(
                        "v1", new OpenApiInfo { Title = "Catalog.API", Version = "v1" }))
                .AddControllers();

        public static void ConfigureWebApp(WebApplication webApp)
        {
            // Configure the HTTP request pipeline.
            if (webApp.Environment.IsDevelopment())
            {
                webApp.ConfigureDevelopmentApp();
                webApp.SeedData();
            }   

            webApp
                .UseHttpsRedirection()
                .UseAuthorization();
            
            webApp.MapControllers();
        }
    }
}