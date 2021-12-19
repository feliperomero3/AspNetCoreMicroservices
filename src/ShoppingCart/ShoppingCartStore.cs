using System.Collections.Generic;

namespace ShoppingCart
{
    public class ShoppingCartStore
    {
        private static readonly Dictionary<int, ShoppingCart> Database = new();

        public ShoppingCart Get(int userId) => Database.ContainsKey(userId) ? Database[userId] : new ShoppingCart(userId);

        public void Save(ShoppingCart shoppingCart) => Database[shoppingCart.UserId] = shoppingCart;
    }
}
