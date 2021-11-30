using System;
using System.Threading.Tasks;
using Catalog.Core.Application.Commands.Abstractions;
using Catalog.Core.Exceptions;
using Catalog.Core.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Catalog.Core.Application.Commands
{
    public class ProductCommandHandler : 
        ICommandHandler<CreateProductCommand>,
        ICommandHandler<DeleteProductCommand>,
        ICommandHandler<UpdateProductCommand>
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
        
        public async Task Handle(UpdateProductCommand command)
        {
            var product = new Product(
                new Identifier(command.Id).ToString(), 
                command.Name,
                command.Category,
                command.Summary,
                command.Description,
                command.ImageFile,
                command.Price);

            var result = await _repository.Update(product);
            if (!result)
            {
                // TODO - add more data to exception & log
                throw new UpdateProductFailed();
            }
        }

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
                // TODO - add more data to exception & log
                throw new DeleteProductFailed();
            }
        }
    }
}