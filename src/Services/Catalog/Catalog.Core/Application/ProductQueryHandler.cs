using Catalog.Core.Application.Abstractions;
using Catalog.Core.Application.Abstractions.Queries;
using Catalog.Core.Exceptions;
using Catalog.Core.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Catalog.Core.Application
{
    public class ProductQueryHandler : IProductQueryHandler
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<ProductQueryHandler> _logger;
        
        public ProductQueryHandler(IProductRepository repository, ILogger<ProductQueryHandler> logger) =>
            (_repository, _logger) = (repository, logger);
        
        public async Task<IEnumerable<Product>> Handle(QueryAllProducts query)
        {
            var allProducts = await _repository.Read();
            return allProducts;
        }

        public async Task<Product> Handle(QueryProductById query)
        {
            var identifier = new Identifier(query.Id);
            var product = await _repository.Read(identifier);
            if (product is null)
            {
                throw new ProductNotFoundException();
            }

            return product;
        }

        public Task<IEnumerable<Product>> Handle(QueryProductByCategory query)
        {
            var specification = new ProductByCategorySpecification(query.Category);
            return _repository.Read(specification);
        }
        
        public Task<IEnumerable<Product>> Handle(QueryProductByName query)
        {
            var specification = new ProductByNameSpecification(query.Name);
            return _repository.Read(specification);
        }
    }
}