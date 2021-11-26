namespace Catalog.Core.Application.Abstractions.Queries
{
    public class QueryProductById : IQuery<Product>
    {
        public string Id { get; }
        
        public QueryProductById(string id)
        {
            Id = id;
        }
    }
}