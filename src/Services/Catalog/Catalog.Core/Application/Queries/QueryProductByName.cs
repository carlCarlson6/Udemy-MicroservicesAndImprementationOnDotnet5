using System.Collections.Generic;
using Catalog.Core.Application.Queries.Abstractions;

namespace Catalog.Core.Application.Queries
{
    public class QueryProductByName : IQuery<IEnumerable<Product>>
    {
        public string Name { get; }
        
        public QueryProductByName(string name)
        {
            Name = name;
        }
    }
}