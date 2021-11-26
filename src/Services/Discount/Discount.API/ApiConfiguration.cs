using Discount.API.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Discount.API
{
    public static class ApiConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, ConfigurationManager configuration) =>
            services
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

        public static void RunApi(string[] arguments)
        {
            var builder = WebApplication.CreateBuilder(arguments);

            ApiConfiguration.ConfigureServices(builder.Services, builder.Configuration);

            var app = builder.Build();
            ApiConfiguration.ConfigureWebApp(app);

            app.Run();
        }
    }
}