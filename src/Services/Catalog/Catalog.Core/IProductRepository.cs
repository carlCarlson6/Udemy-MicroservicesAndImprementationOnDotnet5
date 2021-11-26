using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Core.ValueObjects;

namespace Catalog.Core
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Read();
        Task<Product?> Read(Identifier id);
        Task<IEnumerable<Product>> Read(Specification<Product> specification);

        Task Save(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(Product product);
    }
}