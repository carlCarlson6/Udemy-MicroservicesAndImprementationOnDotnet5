using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            var productsCollection = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            Products = productsCollection;
        }

        public IMongoCollection<Product> Products { get; }
    }
}