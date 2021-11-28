using System;
using System.Threading.Tasks;
using Catalog.Core.Application.Queries.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Core.Application.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public Task<TR> Dispatch<T, TR>(T query) where T : IQuery<TR>
        {
            var handler = _serviceProvider.GetRequiredService<IQueryHandler<T, TR>>();
            return handler.Handle(query);
        }
    }
}