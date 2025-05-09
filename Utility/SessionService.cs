using Newtonsoft.Json;

namespace BookStore.Utility
{
    public static class SessionService
    {
        public const string SessionCart = "SessionShoppingCart";
        private static HttpContext _httpContext => new HttpContextAccessor().HttpContext;

        public static List<CartItem> GetCartItems()
        {
            List<CartItem> cartItems = new List<CartItem>();
            if (_httpContext.Session.GetString(SessionCart) != null)
            {
                cartItems = JsonConvert.DeserializeObject<List<CartItem>>(_httpContext.Session.GetString(SessionCart));
            }
            return cartItems;
        }

        public static void ClearCart()
        {
            _httpContext.Session.Remove(SessionCart);
        }

        public static void SaveCartItems(List<CartItem> cartItems)
        {
            _httpContext.Session.SetString(SessionCart, JsonConvert.SerializeObject(cartItems));
        }
    }
}
