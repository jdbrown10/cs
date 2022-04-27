using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using chefs_and_dishes.Models;
using Microsoft.EntityFrameworkCore;

namespace chefs_and_dishes.Controllers
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
            ViewBag.AllChefs = _context.Chefs.Include(d => d.Repertoire).OrderBy(n => n.LastName).ToList();
            return View();
        }

        // public int GetChefDishes(int chefId)
        // {
        //     int numDishes = _context.Chefs.Include(c => c.Repertoire).FirstOrDefault(c => c.ChefId == chefId).Repertoire.Count;
        //     return numDishes;
        // }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("/new")]
        public IActionResult AddChef()
        {
            return View("AddChef");
        }

        [HttpPost("chef/create")]

        public IActionResult CreateChef(Chef newChef)
        {
            if (ModelState.IsValid)
            {
                _context.Chefs.Add(newChef);
                _context.SaveChanges();
                return RedirectToAction("AddChef");
            } else
            {
                return View("AddChef");
            }
        }

        [HttpGet("dishes")]
        public IActionResult ShowDishes()
        {
            ViewBag.AllDishes = _context.Dishes.Include(a => a.Creator).OrderBy(n => n.Name).ToList();

            return View();
        }

        [HttpGet("new/dish")]
        public IActionResult AddDish()
        {
            ViewBag.AllChefs = _context.Chefs.OrderBy(n => n.LastName).ToList();
            return View();
        }

        [HttpPost("dish/create")]
        public IActionResult CreateDish(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                _context.Dishes.Add(newDish);
                _context.SaveChanges();
                return RedirectToAction("AddDish");
            } else
            {
                ViewBag.AllChefs = _context.Chefs.OrderBy(n => n.LastName).ToList();
                return View("AddDish");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
