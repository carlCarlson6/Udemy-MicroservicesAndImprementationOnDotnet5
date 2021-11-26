using Microsoft.AspNetCore.Builder;

namespace Discount.API.Extensions
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
    }
}