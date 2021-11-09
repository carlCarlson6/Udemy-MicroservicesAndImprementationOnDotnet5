namespace Basket.API.Entities
{
    public class ShoppingCartItem
    {
        public int Quantity { get; }
        public string Color { get; }
        public decimal Price { get; private set; }
        public string ProductId { get; }
        public string ProductName { get; }

        public decimal TotalPrice => Price * Quantity;

        public ShoppingCartItem(int quantity, string color, decimal price, string productId, string productName)
        {
            Quantity = quantity;
            Color = color;
        }

        public void ApplyDiscount()
        {
            return;
        }
    }
}