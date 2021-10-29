using Catalog.API.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IOptions<MongoDbConfiguration> options)
        {
            var configuration = options.Value;
            var client = new MongoClient(configuration.ConnectionString);
            var database = client.GetDatabase(configuration.DatabaseName);
            Products = database.GetCollection<Product>(configuration.CollectionName);
        }

        public IMongoCollection<Product> Products { get; }
    }
}