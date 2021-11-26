using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Catalog.Core;
using Catalog.Core.ValueObjects;
using MongoDB.Driver;

namespace Catalog.MongoDb.Repositories
{
    public class MongoProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public MongoProductRepository(ICatalogContext catalogContext) => _context = catalogContext;

        public Task<IEnumerable<Product>> Read() => ExecuteSearch(p => true); 
        
        public async Task<Product?> Read(Identifier id)
        {
            await _context.Products.Find(p => p.Id.Equals(id)).FirstOrDefaultAsync();
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> Read(Specification<Product> specification) =>
            ExecuteSearch(specification.ToExpression());
        
        private async Task<IEnumerable<Product>> ExecuteSearch(Expression<Func<Product, bool>> filter)
        {
            var products = await _context.Products.Find(filter).ToListAsync();
            return products ?? new List<Product>();
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

        public async Task<bool> Delete(Product product)
        {
            var id = product.Id.ToString();
            var deleteResult = await _context.Products.DeleteManyAsync(p => p.Id.Equals(id));
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}