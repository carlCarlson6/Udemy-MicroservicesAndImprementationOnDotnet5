using Catalog.API;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .ConfigureServices(builder.Configuration);

var app = builder.Build();

app
    .ConfigureWebApp()
    .Run();