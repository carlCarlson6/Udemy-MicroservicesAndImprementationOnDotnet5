using System.Collections.Generic;
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
    public class GetCatalogController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<GetCatalogController> _logger;

        public GetCatalogController(IProductRepository repository, ILogger<GetCatalogController> logger) =>
            (_repository, _logger) = (repository, logger);

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public Task<IEnumerable<Product>> GetProducts() => 
            _repository.Read();

        [HttpGet(ApiRoutes.WithId, Name = nameof(GetProduct))]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            var product = await _repository.Read(id);
            if (product is null)
            {
                _logger.LogError("Product with id {Id} not found", id);
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet(ApiRoutes.WithActionByCategory, Name = nameof(GetProductByCategory))]
        public Task<IEnumerable<Product>> GetProductByCategory(string category) =>
            _repository.ReadByCategory(category);
    }
}