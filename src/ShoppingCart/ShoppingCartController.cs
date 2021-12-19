using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart
{
    [Route("[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ShoppingCartStore _shoppingCartStore;

        public ShoppingCartController(ShoppingCartStore shoppingCartStore)
        {
            _shoppingCartStore = shoppingCartStore;
        }

        [HttpGet("{userId:int}")]
        public ShoppingCart Get(int userId) => _shoppingCartStore.Get(userId);
    }
}
