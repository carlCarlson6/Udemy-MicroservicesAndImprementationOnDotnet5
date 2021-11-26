using System.Collections.Generic;

namespace Catalog.Core.Application.Abstractions.Queries
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