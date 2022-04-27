using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using random_passcode.Models;
using Microsoft.AspNetCore.Http; //this is for using session!

namespace random_passcode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public int counter {get;set;}

        public static String RandomString()
        {
            Random rand = new Random();
            String Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] passcode = new char[Characters.Length];
            for (int i = 0; i < Characters.Length; i++)
            {
                passcode[i] = Characters[rand.Next(Characters.Length)];
            }
            return new string(passcode);
        }

        public int IncreaseCounter()
        {
            this.counter += 1;
            return counter;
        }

        // public void IncreaseCounter()
        // {
        //     if (HttpContext.Session.GetInt32("counter") != null)
        //     {
        //     int? counter = HttpContext.Session.GetInt32("counter");
        //     counter++;
        //     HttpContext.Session.SetInt32("counter", counter);
        //     }
        // }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("inSession") == null)
            {
                Console.WriteLine("There was nothing in session-- creating a new one.");
                HttpContext.Session.SetString("inSession", "Working");
                HttpContext.Session.SetString("passcode", RandomString());
                HttpContext.Session.SetInt32("counter", IncreaseCounter());
                int? i = HttpContext.Session.GetInt32("counter");
            }
            else
            {
                Console.WriteLine("There was already a session.");
            }
            ViewBag.Passcode = HttpContext.Session.GetString("passcode");
            ViewBag.Counter = HttpContext.Session.GetInt32("counter");
            return View("Index");
        }

        [HttpGet("/new_passcode")]
        public IActionResult NewPasscode()
        {
            HttpContext.Session.SetString("passcode", RandomString());
            HttpContext.Session.SetInt32("counter", IncreaseCounter());
            ViewBag.Passcode = HttpContext.Session.GetString("passcode");
            ViewBag.Counter = HttpContext.Session.GetInt32("counter");
            return View("Index");
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
