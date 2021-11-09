using System;
using System.Collections.Generic;
using System.Linq;

namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; }
        public IEnumerable<ShoppingCartItem> Items { get; private set; } = new List<ShoppingCartItem>();

        private ShoppingCart(string userName) => UserName = userName;
        public static ShoppingCart CreateEmptyCart(string userName) => 
            !string.IsNullOrWhiteSpace(userName)? 
                new ShoppingCart(userName): 
                throw new ArgumentNullException(userName);
        
        public static ShoppingCart CreateCart(string userName, IEnumerable<ShoppingCartItem> items)
        {
            var cart = CreateEmptyCart(userName);
            cart.AddItem(items);
            return cart;
        }
        
        public decimal TotalPrice => Items.Sum(item => item.TotalPrice);

        public void AddItem(ShoppingCartItem item) => Items = Items.Append(item);
        public void AddItem(IEnumerable<ShoppingCartItem> items) => Items = Items.Concat(items);
    }
}