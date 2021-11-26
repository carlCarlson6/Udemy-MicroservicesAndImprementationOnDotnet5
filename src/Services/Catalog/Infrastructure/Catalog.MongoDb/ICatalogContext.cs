using Catalog.Core;
using MongoDB.Driver;

namespace Catalog.MongoDb
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}