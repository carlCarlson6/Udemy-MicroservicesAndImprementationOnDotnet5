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
    public class PostCatalogController : ControllerBase
    {
        private readonly ICommandDispatcher _dispatcher;
        private readonly ILogger<PostCatalogController> _logger;

        public PostCatalogController(ICommandDispatcher dispatcher, ILogger<PostCatalogController> logger) =>
            (_dispatcher, _logger) = (dispatcher, logger);

        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] CreateProductCommand command)
        {
            // TODO handler errors
            await _dispatcher.Dispatch(command);
            return CreatedAtRoute(nameof(GetCatalogController.GetProduct), new { id = command.Id }, command);
        }
    }
}