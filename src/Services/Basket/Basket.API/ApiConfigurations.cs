using Basket.API.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Basket.API
{
    public static class ApiConfigurations
    {
        public static void ConfigureServices(IServiceCollection services, ConfigurationManager configuration) =>
            services
                .AddRedis(configuration)
                .AddRepositories()
                .AddApiDocumentation()
                .AddControllers();

        public static void ConfigureWebApp(WebApplication webApp)
        {
            // Configure the HTTP request pipeline.
            if (webApp.Environment.IsDevelopment())
            {
                webApp.ConfigureDevelopmentApp();
            }   

            webApp
                .UseHttpsRedirection()
                .UseAuthorization();
            
            webApp.MapControllers();
        }
    }
}