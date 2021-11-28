using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Catalog.Core;
using Catalog.Core.Application.Queries;
using Catalog.Core.Application.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route(ApiRoutes.BaseCatalogRouteV1)]
    // TODO add logs
    public class GetCatalogController : ControllerBase
    {
        private readonly IQueryDispatcher _dispatcher;
        private readonly ILogger<GetCatalogController> _logger;

        public GetCatalogController(ILogger<GetCatalogController> logger, IQueryDispatcher dispatcher) => 
            (_logger, _dispatcher) = (logger, dispatcher);

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public Task<IEnumerable<Product>> GetProducts() =>
            _dispatcher.Dispatch<QueryAllProducts, IEnumerable<Product>>(new QueryAllProducts());


        [HttpGet(ApiRoutes.WithId, Name = nameof(GetProduct))]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public Task<Product> GetProduct(string id) =>
            _dispatcher.Dispatch<QueryProductById, Product>(new QueryProductById(id));
        
        [HttpGet(ApiRoutes.WithActionByCategory, Name = nameof(GetProductByCategory))]
        public Task<IEnumerable<Product>> GetProductByCategory(string category) =>
            _dispatcher.Dispatch<QueryProductByCategory, IEnumerable<Product>>(
                new QueryProductByCategory(category));
    }
}