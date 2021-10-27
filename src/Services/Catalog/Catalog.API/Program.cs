using Catalog.API;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

ApiConfigurations.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();
ApiConfigurations.ConfigureWebApp(app);

app.Run();