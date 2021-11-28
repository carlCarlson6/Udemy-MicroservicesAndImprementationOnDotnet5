using System;
using System.Net;
using System.Threading.Tasks;
using Catalog.Core;
using Catalog.Core.Application.Commands;
using Catalog.Core.Application.Commands.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route(ApiRoutes.BaseCatalogRouteV1)]
    public class DeleteCatalogController : ControllerBase
    {
        private readonly ICommandDispatcher _dispatcher;
        private readonly ILogger<DeleteCatalogController> _logger;

        public DeleteCatalogController(ICommandDispatcher dispatcher, ILogger<DeleteCatalogController> logger) =>
            (_dispatcher, _logger) = (dispatcher, logger);
        
        [HttpDelete(ApiRoutes.WithId, Name = nameof(DeleteProduct))]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            //_logger.LogInformation("Deleting product with id {Id}", id);
            //return Ok(await _repository.Delete(id));

            var command = new DeleteProductCommand(id);
            await _dispatcher.Dispatch(command);
            
            throw new NotImplementedException();
        }
    }
}