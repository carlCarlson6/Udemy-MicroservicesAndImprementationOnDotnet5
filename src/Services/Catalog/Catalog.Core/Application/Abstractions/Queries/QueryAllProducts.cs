using System.Collections.Generic;
using Catalog.Core.Application.Abstractions;

namespace Catalog.Core.Application.Queries
{
    public class QueryAllProducts: IQuery<QueryAllProductsResponse> { }

    public class QueryAllProductsResponse : TResponse
    {
        public IEnumerable<Product> Products { get; }
        
        public QueryAllProductsResponse(IEnumerable<Product> products) => Products = products;
    }
}