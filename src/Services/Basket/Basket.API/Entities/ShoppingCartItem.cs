using System;

namespace Basket.API.Entities
{
    public class ShoppingCartItem
    {
        public string ProductId { get; }
        public string ProductName { get; }
        public int Quantity { get; }
        public decimal Price { get; private set; }
        public string Color { get; }

        public ShoppingCartItem(int quantity, string color, decimal price, string productId, string productName)
        {
            Quantity = quantity;
            Color = color;
            Price = price;
            ProductId = productId;
            ProductName = productName;
        }
        
        public decimal TotalPrice => Price * Quantity;

        public void ApplyDiscount() => throw new NotImplementedException();
    }
}