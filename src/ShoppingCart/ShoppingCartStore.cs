using System.Collections.Generic;

namespace ShoppingCart
{
    public class ShoppingCartStore
    {
        private static readonly Dictionary<int, ShoppingCart> _database = new();

        public ShoppingCartStore()
        {
            //Seed();
        }

        public ShoppingCart Get(int userId) => _database.ContainsKey(userId) ? _database[userId] : new ShoppingCart(userId);

        public void Save(ShoppingCart shoppingCart) => _database[shoppingCart.UserId] = shoppingCart;

        public static void Seed()
        {
            if (_database.Count > 0)
            {
                return;
            }

            var item1 = new ShoppingCartItem(1, "Basic t-shirt", "a quiet t-shirt", new Money("eur", 40));
            var item2 = new ShoppingCartItem(2, "Fancy shirt", "a loud t-shirt", new Money("eur", 50));

            var cart = new ShoppingCart(42);

            cart.AddItems(new[] { item1, item2 });

            _database.Add(42, cart);
        }
    }
}
