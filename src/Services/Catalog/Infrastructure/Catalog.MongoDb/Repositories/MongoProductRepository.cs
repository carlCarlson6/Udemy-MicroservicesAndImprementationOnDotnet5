using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Data;
using Catalog.Core;
using MongoDB.Driver;
using Product = Catalog.Core.Product;

namespace Catalog.API.Repositories
{
    public class MongoProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public MongoProductRepository(ICatalogContext catalogContext) => _context = catalogContext;

        public async Task<IEnumerable<Product>> Read()
        {
            // await _context.Products.Find(p => true).ToListAsync();
            throw new NotImplementedException();
        }


        public async Task<Product?> Read(string id)
        {
            //await _context.Products.Find(p => p.Id.Equals(id)).FirstOrDefaultAsync();
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> ReadByName(string name)
        {
            //var nameFilter = Builders<Product>.Filter.ElemMatch(p => p.Name, name);
            //return ExecuteSearch(nameFilter);
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> ReadByCategory(string categoryName)
        {
            //var categoryFilter = Builders<Product>.Filter.Eq(p => p.Category, categoryName); 
            //return ExecuteSearch(categoryFilter);
            throw new NotImplementedException();
        }

        private async Task<IEnumerable<Product>> ExecuteSearch(FilterDefinition<Product> filter)
        {
            //await _context.Products.Find(filter).ToListAsync();
            throw new NotImplementedException();
        }

        public Task Save(Product product)
        {
            //_context.Products.InsertOneAsync(product);
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Product product)
        {
            //var updateResult = await _context.Products.ReplaceOneAsync(p => p.Id.Equals(product.Id), product);
            //return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(string id)
        {
            var deleteResult = await _context.Products.DeleteManyAsync(p => p.Id.Equals(id));
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}