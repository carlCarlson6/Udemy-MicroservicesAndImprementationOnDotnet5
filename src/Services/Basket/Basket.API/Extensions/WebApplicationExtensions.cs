using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Basket.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void ConfigureDevelopmentApp(this WebApplication webApp) =>
            webApp
                .UseSwagger()
                .UseSwaggerUI(c =>
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API v1"));
    }
}