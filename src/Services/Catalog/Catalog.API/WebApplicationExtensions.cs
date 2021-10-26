using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Catalog.API
{
    public static class WebApplicationExtensions
    {
        public static WebApplication ConfigureWebApp(this WebApplication webApp)
        {
            // Configure the HTTP request pipeline.
            if (webApp.Environment.IsDevelopment())
            {
                webApp.UseSwagger();
                webApp.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API v1"));
            }

            webApp.UseHttpsRedirection();
            webApp.UseAuthorization();
            webApp.MapControllers();

            return webApp;
        }
    }
}