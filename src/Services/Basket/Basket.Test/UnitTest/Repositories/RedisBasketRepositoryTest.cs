using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Basket.API.Entities;
using Basket.API.Repositories;
using Basket.API.Repositories.Models;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NFluent;

namespace Basket.Test.UnitTest.Repositories
{
    [TestClass]
    public class RedisBasketRepositoryTest
    {
        private RedisBasketRepository _repository = null!;
        private Mock<IDistributedCache> _cacheMock = null!;
        
        [TestInitialize]
        public void BeforeEach()
        {
            _cacheMock = new Mock<IDistributedCache>(MockBehavior.Strict);
            _repository = new RedisBasketRepository(_cacheMock.Object);
        }
        
        [TestMethod]
        public async Task GivenAStoredBasket_WhenReadBasket_ThenABasketIsReturned()
        {
            var basket = new ShoppingCartModel
            {
                UserName = "some-userName",
                Items = new List<ShoppingCartItemModel>
                {
                    new()
                    {
                        Color = "some-color",
                        Price = 66,
                        ProductId = "some-id",
                        ProductName = "some-productName",
                        Quantity = 42
                    }
                }
            };
            
            var stringBasket = JsonSerializer.Serialize(basket);
            
            _cacheMock.Setup(cm => 
                    cm.GetAsync(basket.UserName, It.IsAny<CancellationToken>()))
                .ReturnsAsync(Encoding.UTF8.GetBytes(stringBasket));

            var retrievedBasket = await _repository.ReadBasket(basket.UserName);

            Check.That(retrievedBasket).IsNotNull();
        }
    }
}