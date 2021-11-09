using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Basket.API.Entities;

namespace Basket.API.Repositories.Models
{
    public class ShoppingCartModel
    {
        public string UserName { get; set; }
        public IEnumerable<ShoppingCartItemModel> Items { get; set; }

        public ShoppingCart ToEntity() =>
            ShoppingCart.CreateCart(
                UserName,
                Items.Select(item =>
                    new ShoppingCartItem(
                        item.Quantity,
                        item.Color,
                        item.Price,
                        item.ProductId,
                        item.ProductName)));
        
        public static ShoppingCartModel? Deserialize(string stringModel) => 
            JsonSerializer.Deserialize<ShoppingCartModel>(stringModel);

        public static ShoppingCartModel FromEntity(ShoppingCart shoppingCart) =>
            new()
            {
                UserName = shoppingCart.UserName,
                Items = shoppingCart.Items.Select(item => new ShoppingCartItemModel
                {
                    ProductId = item.ProductId, 
                    Color = item.Color, 
                    Price = item.Price, 
                    ProductName = item.ProductName,
                    Quantity = item.Quantity
                })
            };
    }

    public class ShoppingCartItemModel
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
    }
}