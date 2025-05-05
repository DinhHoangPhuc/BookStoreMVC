using BookStore.Repository.IRepository;
using BookStore.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public const string SessionCart = "SessionShoppingCart";

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View(GetCartItems());
        }

        public IActionResult AddToCart(int productId)
        {
            var product = _unitOfWork.ProductRepository.Get(p => p.Id == productId);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            var cartItems = GetCartItems();
            var existingItem = cartItems.FirstOrDefault(c => c.Product.Id == productId);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cartItems.Add(new CartItem { Product = product, Quantity = 1 });
            }
            SaveCartItems(cartItems);

            TempData["success"] = "Product added to cart successfully";
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            var cart = GetCartItems();
            var cartItem = cart.FirstOrDefault(c => c.Product.Id == productId);
            if (cartItem != null)
            {
                cart.Remove(cartItem);
            }
            SaveCartItems(cart);

            TempData["success"] = "Product removed from cart successfully";
            return RedirectToAction("Index");   
        }

        [HttpPost]
        public IActionResult UpdateCart(int productId, int quantity)
        {
            var cart = GetCartItems();
            var cartItem = cart.FirstOrDefault(c => c.Product.Id == productId);
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
            }
            SaveCartItems(cart);
            // Logic to clear the cart
            TempData["success"] = "Cart updated successfully";
            return Ok();
        }

        public IActionResult CheckOut()
        {
            // Logic to proceed to checkout
            TempData["success"] = "Proceeding to checkout";
            return RedirectToAction("Index");
        }

        List<CartItem> GetCartItems()
        {
            List<CartItem> cartItems = new List<CartItem>();
            if (HttpContext.Session.GetString(SessionCart) != null)
            {
                cartItems = JsonConvert.DeserializeObject<List<CartItem>>(HttpContext.Session.GetString(SessionCart));
            }
            return cartItems;
        }

        void ClearCart()
        {
            HttpContext.Session.Remove(SessionCart);
        }

        void SaveCartItems(List<CartItem> cartItems)
        {
            HttpContext.Session.SetString(SessionCart, JsonConvert.SerializeObject(cartItems));
        }
    }
}
