using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public class ShoppingCart
    {
        private readonly HashSet<ShoppingCartItem> _items = new();

        public ShoppingCart(int userId) => UserId = userId;

        public int UserId { get; }

        public IEnumerable<ShoppingCartItem> Items => _items;

        public void AddItems(IEnumerable<ShoppingCartItem> shoppingCartItems)
        {
            foreach (var item in shoppingCartItems)
            {
                _items.Add(item);
            }
        }

        public void RemoveItems(int[] productCatalogueIds) => _items.RemoveWhere(i => productCatalogueIds.Contains(i.ProductCatalogueId));
    }
}
