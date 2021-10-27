using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Entities;

namespace Catalog.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Read();
        Task<Product?> Read(string id);
        Task<IEnumerable<Product>> ReadByName(string name);
        Task<IEnumerable<Product>> ReadByCategory(string categoryName);

        Task Save(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(string id);
    }
}