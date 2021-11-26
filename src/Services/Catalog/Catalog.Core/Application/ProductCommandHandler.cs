using System.Threading.Tasks;
using Catalog.Core.Application.Abstractions;
using Catalog.Core.Application.Abstractions.Commands;
using Catalog.Core.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Catalog.Core.Application
{
    public class ProductCommandHandler : IProductCommandHandler
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<ProductCommandHandler> _logger;

        public ProductCommandHandler(IProductRepository repository, ILogger<ProductCommandHandler> logger) =>
            (_repository, _logger) = (repository, logger);
        
        public async Task Handle(CreateProductCommand command)
        {
            var identifier = new Identifier(command.Id);
            
            var product = new Product(identifier);

            _logger.LogInformation("Adding product {@Product}", command);
            await _repository.Save(product);
        }
        
        public Task Handle(UpdateProductCommand command)
        {
            throw new System.NotImplementedException();
        }

        public Task Handle(DeleteProductCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}