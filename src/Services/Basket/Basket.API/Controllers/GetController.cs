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
    public class GetController : ControllerBase
    {
        private readonly IBasketRepository _repository;
        private readonly ILogger<GetController> _logger;

        public GetController(IBasketRepository repository, ILogger<GetController> logger) =>
            (_repository, _logger) = (repository, logger);

        [HttpGet(ApiRoutes.WithUserName, Name = nameof(GetBasket))]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {
            var basket = await _repository.ReadBasket(userName) 
                         ?? ShoppingCart.CreateEmptyCart(userName);
            return Ok(basket);
        }
    }
}