using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext catalogContext) => 
            _context = catalogContext;

        public async Task<IEnumerable<Product>> Read() =>
            await _context.Products
                .Find(p => true)
                .ToListAsync();

        public async Task<Product?> Read(string id) =>
            await _context.Products
                .Find(p => p.Id.Equals(id))
                .FirstOrDefaultAsync();

        public Task<IEnumerable<Product>> ReadByName(string name)
        {
            var nameFilter = Builders<Product>.Filter.ElemMatch(p => p.Name, name);
            return ExecuteSearch(nameFilter);
        }

        public Task<IEnumerable<Product>> ReadByCategory(string categoryName)
        {
            var categoryFilter = Builders<Product>.Filter.Eq(p => p.Category, categoryName); 
            return ExecuteSearch(categoryFilter);
        }
        
        private async Task<IEnumerable<Product>> ExecuteSearch(FilterDefinition<Product> filter) =>  
            await _context.Products
                .Find(filter)
                .ToListAsync();

        public Task Save(Product product) => _context.Products.InsertOneAsync(product);

        public async Task<bool> Update(Product product)
        {
            var updateResult = await _context.Products
                .ReplaceOneAsync(p => p.Id.Equals(product.Id), product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            var deleteResult = await _context.Products.DeleteManyAsync(p => p.Id.Equals(id));
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}