using System.Collections.Generic;

namespace Catalog.Core.Application.Abstractions.Queries
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