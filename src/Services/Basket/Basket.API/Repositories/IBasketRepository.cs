using System.Threading.Tasks;
using Basket.API.Entities;

namespace Basket.API.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart?> ReadBasket(string userName);
        Task<ShoppingCart> UpsertBasket(ShoppingCart basket);
        Task DeleteBasket(string userName);
    }
}