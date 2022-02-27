using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart
{
    [Route("[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ShoppingCartStore _shoppingCartStore;
        private readonly ProductCatalogClient _productCatalogClient;

        public ShoppingCartController(ShoppingCartStore shoppingCartStore, ProductCatalogClient productCatalogClient)
        {
            _shoppingCartStore = shoppingCartStore;
            _productCatalogClient = productCatalogClient;
        }

        [HttpGet("{userId:int}")]
        public ShoppingCart Get(int userId) => _shoppingCartStore.Get(userId);

        [HttpPost("{userId:int}/items")]
        public async Task<ShoppingCart> Post(int userId, [FromBody] int[] productIds)
        {
            var shoppingCart = _shoppingCartStore.Get(userId);

            var shoppingCartItems = await _productCatalogClient.GetShoppingCartItems(productIds);

            shoppingCart.AddItems(shoppingCartItems);

            _shoppingCartStore.Save(shoppingCart);

            return shoppingCart;
        }

        [HttpDelete("{userId:int}")]
        public ShoppingCart Delete(int userId, [FromBody] int[] productIds)
        {
            var shoppingCart = _shoppingCartStore.Get(userId);

            shoppingCart.RemoveItems(productIds);

            _shoppingCartStore.Save(shoppingCart);

            return shoppingCart;
        }
    }
}
