using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Description = "Description for product 1", Price = 19.99m, ImageUrl = "https://via.placeholder.com/150" },
            new Product { Id = 2, Name = "Product 2", Description = "Description for product 2", Price = 29.99m, ImageUrl = "https://via.placeholder.com/150" },
            new Product { Id = 3, Name = "Product 3", Description = "Description for product 3", Price = 39.99m, ImageUrl = "https://via.placeholder.com/150" }
        };

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            return View(product);
        }
    }
}
