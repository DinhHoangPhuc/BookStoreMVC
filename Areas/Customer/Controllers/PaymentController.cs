using BookStore.Constant;
using BookStore.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Stripe;
using Stripe.Checkout;

namespace BookStore.Areas.Customer.Controllers
{
    [Area(RoleConstant.Role_User_Customer)]
    [Authorize(Roles = RoleConstant.Role_User_Customer)]
    public class PaymentController : Controller
    {
        private readonly StripeSettings _stripeSettings;

        public PaymentController(IOptions<StripeSettings> stripeSettings)
        {
            _stripeSettings = stripeSettings.Value;
        }

        public IActionResult CheckOut()
        {
            ViewBag.PublishableKey = _stripeSettings.PublishableKey;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCheckoutSession()
        {
            List<CartItem> cartItems = new List<CartItem>();
            if (HttpContext.Session.GetString("SessionShoppingCart") != null)
            {
                cartItems = JsonConvert.DeserializeObject<List<CartItem>>(HttpContext.Session.GetString("SessionShoppingCart"));
            }
            else
            {
                TempData["error"] = "Your cart is empty.";
                return RedirectToAction("Index", "Cart");
            }

            var lineItems = cartItems.Select(i => new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    Currency = "vnd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = i.Product.Title,
                        Metadata = new Dictionary<string, string>
                        {
                            { "ProductId", i.Product.Id.ToString() },
                        },
                        //Image must be access online, other wise it will not work
                        //Images = new List<string>
                        //{
                        //    i.Product.ImageUrl,
                        //},
                    },
                    UnitAmount = (long)(i.Product.ListPrice),
                },
                Quantity = i.Quantity,
            }).ToList();

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = Url.Action("Success", "Payment", null, Request.Scheme),
                CancelUrl = Url.Action("Cancel", "Payment", null, Request.Scheme),
                //SuccessUrl = _stripeSettings.SuccessUrl,
                //CancelUrl = _stripeSettings.CancelUrl,
            };
            try
            {
                Stripe.Checkout.SessionService service = new Stripe.Checkout.SessionService();
                Session session = await service.CreateAsync(options);
                //var session = service.Create(options);
                //Response.Headers.Add("Location", session.Url);
                return Json(new { sessionId = session.Id });
                //return Json(new { url = session.Url });
            }
            catch(StripeException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Cancel()
        {
            return View();
        }
    }
}
