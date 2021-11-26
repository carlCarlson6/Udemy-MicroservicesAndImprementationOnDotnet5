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
    public class PutCatalogController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<PutCatalogController> _logger;

        public PutCatalogController(IProductRepository repository, ILogger<PutCatalogController> logger) =>
            (_repository, _logger) = (repository, logger);

        [HttpPut]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            _logger.LogInformation("Updating product {@Product}", product);
            return Ok(await _repository.Update(product));
        }
    }
}