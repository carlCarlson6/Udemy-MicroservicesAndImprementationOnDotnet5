using System.Collections.Generic;
using Catalog.Core.Application.Queries.Abstractions;

namespace Catalog.Core.Application.Queries
{
    public class QueryAllProducts: IQuery<IEnumerable<Product>> { }
}