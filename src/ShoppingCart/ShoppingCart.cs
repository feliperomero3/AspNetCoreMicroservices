using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public class ShoppingCart
    {
        private readonly HashSet<ShoppingCartItem> _items = new();
        private readonly EventStore _eventStore;

        public ShoppingCart(int userId)
        {
            UserId = userId;
        }

        public ShoppingCart(int userId, EventStore eventStore)
        {
            UserId = userId;
            _eventStore = eventStore;
        }

        public int UserId { get; }

        public IEnumerable<ShoppingCartItem> Items => _items;

        public void AddItems(IEnumerable<ShoppingCartItem> shoppingCartItems)
        {
            foreach (var item in shoppingCartItems)
            {
                var isAdded = _items.Add(item);

                if (isAdded)
                {
                    _eventStore.Raise("ShoppingCartItemAdded", new { userId = UserId, item = item });
                }
            }
        }

        public void RemoveItems(int[] productCatalogueIds)
        {
            foreach (var productId in productCatalogueIds)
            {
                var item = _items.FirstOrDefault(item => item.ProductCatalogueId == productId);

                if (item != null)
                {
                    _items.Remove(item);
                    _eventStore.Raise("ShoppingCartItemRemoved", new { userId = UserId, item = item });
                }
            }
        }
    }
}
