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
    public class DeleteCatalogController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<DeleteCatalogController> _logger;

        public DeleteCatalogController(IProductRepository repository, ILogger<DeleteCatalogController> logger) =>
            (_repository, _logger) = (repository, logger);
        
        [HttpDelete(ApiRoutes.WithId, Name = nameof(DeleteProduct))]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            _logger.LogInformation("Deleting product with id {Id}", id);
            return Ok(await _repository.Delete(id));
        }
    }
}