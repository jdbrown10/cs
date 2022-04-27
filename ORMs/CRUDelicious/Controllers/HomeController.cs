using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
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

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.AllDishes = _context.Dishes.ToList();
            return View();
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpGet("Show/{DishId}")]
        public IActionResult ShowDish(int DishId)
        {
            ViewBag.Dish = _context.Dishes.FirstOrDefault(d => d.DishId == DishId);
            return View();
        }

        [HttpPost("dishes/add")]
        public IActionResult AddDish(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newDish);
                _context.SaveChanges();
                return RedirectToAction("New");
            } else {
                return View("New");
            }
        }

        [HttpGet("/delete/{DishId}")]
        public IActionResult DeleteDish(int DishId)
        {
            Dish DishToRemove = _context.Dishes.SingleOrDefault(d => d.DishId == DishId);
            _context.Dishes.Remove(DishToRemove);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("/update/{DishId}")]
        public IActionResult EditDish(int DishId)
        {
            Dish DishToUpdate = _context.Dishes.FirstOrDefault(d => d.DishId == DishId);
            return View("EditDish", DishToUpdate); 
        }

        [HttpPost("/dish/update/{DishId}")]
        public IActionResult UpdateDish(int DishId, Dish updatedDish)
        {
            if (ModelState.IsValid)
            {
                Dish OldDish = _context.Dishes.FirstOrDefault(d => d.DishId == DishId);
                OldDish.Name = updatedDish.Name;
                OldDish.Chef = updatedDish.Chef;
                OldDish.Tastiness = updatedDish.Tastiness;
                OldDish.Calories = updatedDish.Calories;
                OldDish.Description = updatedDish.Description;
                OldDish.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else {
                return View("EditDish", updatedDish);
            }
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
