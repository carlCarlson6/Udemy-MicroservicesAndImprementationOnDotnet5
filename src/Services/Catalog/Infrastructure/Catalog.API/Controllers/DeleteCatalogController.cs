using System;
using System.Net;
using System.Threading.Tasks;
using Catalog.Core;
using Catalog.Core.Application.Abstractions;
using Catalog.Core.Application.Abstractions.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route(ApiRoutes.BaseCatalogRouteV1)]
    public class DeleteCatalogController : ControllerBase
    {
        private readonly IProductCommandHandler _handler;
        private readonly ILogger<DeleteCatalogController> _logger;

        public DeleteCatalogController(IProductCommandHandler handler, ILogger<DeleteCatalogController> logger) =>
            (_handler, _logger) = (handler, logger);
        
        [HttpDelete(ApiRoutes.WithId, Name = nameof(DeleteProduct))]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            //_logger.LogInformation("Deleting product with id {Id}", id);
            //return Ok(await _repository.Delete(id));

            var command = new DeleteProductCommand(id);
            await _handler.Handle(command);
            
            throw new NotImplementedException();
        }
    }
}