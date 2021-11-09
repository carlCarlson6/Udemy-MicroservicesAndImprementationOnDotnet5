using System;
using System.Net;
using System.Threading.Tasks;
using Basket.API.Entities;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route(ApiRoutes.BaseBasketRouteV1)]
    public class PostController : ControllerBase
    {
        private readonly IBasketRepository _repository;
        private readonly ILogger<PostController> _logger;

        public PostController(IBasketRepository repository, ILogger<PostController> logger) =>
            (_repository, _logger) = (repository, logger);
        
        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> PutBasket([FromBody] ShoppingCart cart)
        {
            var savedCart = await _repository.UpsertBasket(cart);
            return Ok(savedCart);
        }

        // TODO
        // get existing basket with total price 
        // Create basketCheckoutEvent -- Set TotalPrice on basketCheckout eventMessage
        // send checkout event to rabbitmq
        // remove the basket
        [HttpPost(ApiRoutes.WithCheckout)]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Checkout([FromBody] BasketCheckout basketCheckout)
        {
            throw new NotImplementedException();
        }
    }
}