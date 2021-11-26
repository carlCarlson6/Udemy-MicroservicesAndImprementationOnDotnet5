using System.Net;
using System.Threading.Tasks;
using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route(ApiRoutes.BaseCatalogRouteV1)]
    public class PostCatalogController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<PostCatalogController> _logger;

        public PostCatalogController(IProductRepository repository, ILogger<PostCatalogController> logger) =>
            (_repository, _logger) = (repository, logger);

        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            _logger.LogInformation("Adding product {@Product}", product);
            await _repository.Save(product);
            return CreatedAtRoute(nameof(GetCatalogController.GetProduct), new { id = product.Id }, product);
        }
    }
}