using System.Collections.Generic;
using System.Linq;
using Basket.API.Entities;

namespace Basket.API.Controllers.Models
{
    public class UpdateBasketRequest
    {
        public string UserName { get; set; }
        public IEnumerable<UpdateBasketItemRequest> Items { get; set; }

        public ShoppingCart ToEntity() =>
            ShoppingCart.CreateCart(
                UserName,
                Items.Select(item => new ShoppingCartItem(
                    item.Quantity,
                    item.Color,
                    item.Price,
                    item.ProductId,
                    item.ProductName)));
    }

    public class UpdateBasketItemRequest
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
    }
}