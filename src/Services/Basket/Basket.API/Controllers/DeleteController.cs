using System.Net;
using System.Threading.Tasks;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route(ApiRoutes.BaseBasketRouteV1)]
    public class DeleteController : ControllerBase
    {
        private readonly IBasketRepository _repository;
        private readonly ILogger<DeleteController> _logger;

        public DeleteController(IBasketRepository repository, ILogger<DeleteController> logger) =>
            (_repository, _logger) = (repository, logger);

        [HttpDelete(ApiRoutes.WithUserName, Name = nameof(DeleteBasket))]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await _repository.DeleteBasket(userName);
            return Ok();
        }
    }
}