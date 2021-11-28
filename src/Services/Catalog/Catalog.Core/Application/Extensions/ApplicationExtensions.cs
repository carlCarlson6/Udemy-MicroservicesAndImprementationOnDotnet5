using System.Collections.Generic;
using Catalog.Core.Application.Commands;
using Catalog.Core.Application.Commands.Abstractions;
using Catalog.Core.Application.Queries;
using Catalog.Core.Application.Queries.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Core.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddQueries(this IServiceCollection services) => 
            services
                .AddScoped<IQueryDispatcher, QueryDispatcher>()
                .AddScoped<IQueryHandler<QueryAllProducts, IEnumerable<Product>>, ProductQueryHandler>()
                .AddScoped<IQueryHandler<QueryProductByCategory, IEnumerable<Product>>, ProductQueryHandler>()
                .AddScoped<IQueryHandler<QueryProductByName, IEnumerable<Product>>, ProductQueryHandler>()
                .AddScoped<IQueryHandler<QueryProductById, Product>, ProductQueryHandler>();

        public static IServiceCollection AddCommands(this IServiceCollection services) =>
            services
                .AddScoped<ICommandDispatcher, CommandDispatcher>()
                .AddScoped<ICommandHandler<CreateProductCommand>, ProductCommandHandler>()
                .AddScoped<ICommandHandler<UpdateProductCommand>, ProductCommandHandler>()
                .AddScoped<ICommandHandler<DeleteProductCommand>, ProductCommandHandler>();
    }
}