using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Catalog.Core;
using Catalog.Core.Application.Abstractions;
using Catalog.Core.Application.Abstractions.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route(ApiRoutes.BaseCatalogRouteV1)]
    public class GetCatalogController : ControllerBase
    {
        private readonly IProductQueryHandler _handler;
        private readonly ILogger<GetCatalogController> _logger;

        public GetCatalogController(ILogger<GetCatalogController> logger, IProductQueryHandler handler) => 
            (_logger, _handler) = (logger, handler);

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public Task<IEnumerable<Product>> GetProducts() => _handler.Handle(new QueryAllProducts());


        [HttpGet(ApiRoutes.WithId, Name = nameof(GetProduct))]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public Task<Product> GetProduct(string id) =>
            _handler.Handle(
                new QueryProductById(id));
        
        [HttpGet(ApiRoutes.WithActionByCategory, Name = nameof(GetProductByCategory))]
        public Task<IEnumerable<Product>> GetProductByCategory(string category) =>
            _handler.Handle(
                new QueryProductByCategory(category));
    }
}