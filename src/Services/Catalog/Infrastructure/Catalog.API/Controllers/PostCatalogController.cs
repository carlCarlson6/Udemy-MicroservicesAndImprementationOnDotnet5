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
    public class PostCatalogController : ControllerBase
    {
        private readonly IProductCommandHandler _handler;
        private readonly ILogger<PostCatalogController> _logger;

        public PostCatalogController(IProductCommandHandler handler, ILogger<PostCatalogController> logger) =>
            (_handler, _logger) = (handler, logger);

        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] CreateProductCommand command)
        {
            // TODO handler errors
            await _handler.Handle(command);
            return CreatedAtRoute(nameof(GetCatalogController.GetProduct), new { id = command.Id }, command);
        }
    }
}