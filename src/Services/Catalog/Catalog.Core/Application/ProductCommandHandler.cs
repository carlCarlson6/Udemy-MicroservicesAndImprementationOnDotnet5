using Catalog.Core.Application.Abstractions;
using Catalog.Core.Application.Abstractions.Commands;
using Catalog.Core.Exceptions;
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
            
            var product = new Product(
            identifier.ToString(), 
            command.Name,
            command.Category,
            command.Summary,
            command.Description,
            command.ImageFile,
            command.Price);

            _logger.LogInformation("Adding product {@Product}", command);
            await _repository.Save(product);
        }
        
        public Task Handle(UpdateProductCommand command)
        {
            throw new System.NotImplementedException();
        }

        // TODO - add logs
        public async Task Handle(DeleteProductCommand command)
        {
            var identifier = new Identifier(command.Id);

            var productToDelete = await _repository.Read(identifier);
            if (productToDelete is null)
            {
                throw new ProductNotFoundException();
            }

            _logger.LogInformation("Deleting product with id {Id}",productToDelete.Id);
            
            var result = await _repository.Delete(productToDelete);
            if (!result)
            {
                // TODO - throw domain exception
                throw new Exception();
            }
        }
    }
}