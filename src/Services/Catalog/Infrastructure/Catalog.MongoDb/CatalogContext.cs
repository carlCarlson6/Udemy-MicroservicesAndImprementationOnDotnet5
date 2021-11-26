using Catalog.Core;
using MongoDB.Driver;

namespace Catalog.MongoDb
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(MongoDbConfiguration mongoDbConfiguration)
        {
            var client = new MongoClient(mongoDbConfiguration.ConnectionString);
            var database = client.GetDatabase(mongoDbConfiguration.DatabaseName);
            Products = database.GetCollection<Product>(mongoDbConfiguration.CollectionName);
        }

        public IMongoCollection<Product> Products { get; }
    }
}