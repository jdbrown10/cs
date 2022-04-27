using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using products_and_categories.Models;
using Microsoft.EntityFrameworkCore;

namespace products_and_categories.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.AllProducts = _context.Products.OrderBy(a => a.Name).ToList();
            return View();
        }

        [HttpGet("/Categories")]
        public IActionResult Categories()
        {
            ViewBag.AllCategories = _context.Categories.OrderBy(a => a.Name).ToList();
            return View();
        }

        [HttpPost("product/add")]
        public IActionResult AddProduct(Product newProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(newProduct);
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else {
                ViewBag.AllProducts = _context.Products.OrderBy(a => a.Name).ToList();
                return View("Index");
            }
        }

        [HttpPost("category/add")]
        public IActionResult AddCategory(Category newCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(newCategory);
                _context.SaveChanges();
                return RedirectToAction("Categories");
            } else {
                ViewBag.AllCategories = _context.Categories.OrderBy(a => a.Name).ToList();
                return View("Categories");
            }
        }

        [HttpGet("product/{ProdId}")]
        public IActionResult OneProduct(int ProdId)
        {
            ViewBag.OneProduct = _context.Products.Include(a => a.CategoriesIncludedIn).ThenInclude(b => b.Category).FirstOrDefault(c => c.ProductId == ProdId);
            ViewBag.AllCategories = _context.Categories.OrderBy(d => d.Name).ToList();
            return View();
        }

        [HttpGet("category/{CatId}")]
        public IActionResult OneCategory(int CatId)
        {
            ViewBag.OneCategory = _context.Categories.Include(a => a.IncludedProducts).ThenInclude(g => g.Product). FirstOrDefault(a => a.CategoryId == CatId);
            ViewBag.AllProducts = _context.Products.OrderBy(a => a.Name).ToList();
            return View();
        }

        [HttpPost("productcategory/add")]
        public IActionResult AddProductCategory(ProductCategory newProductCategory)
        {
            _context.ProductCategories.Add(newProductCategory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
