using System.Collections.Generic;
using Catalog.Core.Application.Abstractions;

namespace Catalog.Core.Application.Queries
{
    public class QueryProductByCategory : IQuery<IEnumerable<Product>>
    {
        public string Category { get; }
        
        public QueryProductByCategory(string category)
        {
            Category = category;
        }
    }
}