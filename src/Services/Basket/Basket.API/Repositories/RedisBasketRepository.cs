using System;
using System.Text.Json;
using System.Threading.Tasks;
using Basket.API.Entities;
using Basket.API.Repositories.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace Basket.API.Repositories
{
    public class RedisBasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redis;

        public RedisBasketRepository(IDistributedCache distributedRedis) => _redis = distributedRedis;
        
        public async Task<ShoppingCart?> ReadBasket(string userName)
        {
            var basketString = await _redis.GetStringAsync(userName);
            return ShoppingCartModel.Deserialize(basketString)?.ToEntity();
        }

        public async Task<ShoppingCart> UpsertBasket(ShoppingCart basket)
        {
            await _redis.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket));
            var savedBasket = await ReadBasket(basket.UserName);
            if (savedBasket is null)
            {
                throw new Exception();
            }

            return basket;
        }

        public Task DeleteBasket(string userName) => _redis.RemoveAsync(userName);
    }
}