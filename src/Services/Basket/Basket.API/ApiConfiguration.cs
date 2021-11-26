using Basket.API.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Basket.API
{
    public static class ApiConfiguration
    {
        private static void ConfigureServices(IServiceCollection services, ConfigurationManager configuration) =>
            services
                .AddRedis(configuration)
                .AddRepositories()
                .AddApplicationServices()
                .AddApiDocumentation()
                .AddControllers();

        private static void ConfigureWebApp(WebApplication webApp)
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

        public static void RunApi(string[] arguments)
        {
            var builder = WebApplication.CreateBuilder(arguments);

            ConfigureServices(builder.Services, builder.Configuration);

            var app = builder.Build();
            ConfigureWebApp(app);

            app.Run();
        }
    }
}