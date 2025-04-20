using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.Controllers
{
    public class CartController : Controller
    {
        private const string CartSessionKey = "CartSession";

        private List<CartItem> GetCart()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSessionKey);
            if (cart == null)
            {
                cart = new List<CartItem>();
                HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);
            }
            return cart;
        }

        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        public IActionResult AddToCart(int productId)
        {
            var products = HomeController.products;
            var product = products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                return NotFound();

            var cart = GetCart();
            var cartItem = cart.FirstOrDefault(c => c.ProductId == productId);
            if (cartItem == null)
            {
                cart.Add(new CartItem { ProductId = productId, Product = product, Quantity = 1 });
            }
            else
            {
                cartItem.Quantity++;
            }
            HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            var cart = GetCart();
            var cartItem = cart.FirstOrDefault(c => c.ProductId == productId);
            if (cartItem != null)
            {
                cart.Remove(cartItem);
                HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            var cart = GetCart();
            if (cart.Count == 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var cart = GetCart();
            if (cart.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty.");
                return View(order);
            }

            order.Items = cart;
            order.TotalAmount = cart.Sum(c => c.Product.Price * c.Quantity);
            order.OrderDate = System.DateTime.Now;

            // Here you would normally save the order to a database

            HttpContext.Session.Remove(CartSessionKey);

            return RedirectToAction("Index", "Home");
        }
    }
}
