using Catalog.Core.Application.Abstractions;

namespace Catalog.Core.Application.Queries
{
    public class QueryProductById : IQuery<Product>
    {
        public string Id { get; }
        
        public QueryProductById(string id)
        {
            Id = id;
        }
    }
}