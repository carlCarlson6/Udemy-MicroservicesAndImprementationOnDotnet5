using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Core.Application.Abstractions.Queries;

namespace Catalog.Core.Application.Abstractions
{
    public interface IProductQueryHandler
    {
        Task<IEnumerable<Product>> Handle(QueryAllProducts query);
        Task<Product> Handle(QueryProductById query);
        Task<IEnumerable<Product>> Handle(QueryProductByCategory query);
        Task<IEnumerable<Product>> Handle(QueryProductByName query);
    }
}