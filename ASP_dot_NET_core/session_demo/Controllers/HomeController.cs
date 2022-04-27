using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using session_demo.Models;

//this is where everything dealing with session lives, so you have to add this
using Microsoft.AspNetCore.Http;

namespace session_demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // //you have to set up session before you can update it
            // HttpContext.Session.SetString("name", "Josh"); //you can think of session like a Dictionary. It has a key and a value, and the key is what allows us to access the value. The key is a string with some kind of name (in this case, "name"), and the value is whatever you tell session to set -- in this case, it's setting a string "Josh", but the value could also be an integer. 

            // //once we've set it, now we can get it
            // //when you get something from session, pass in the key as the parameter to get the value (in this case, "name")
            // string myName = HttpContext.Session.GetString("name");

            // Console.WriteLine(myName);

            // //you could either pass the data using a viewbag or through viewmodel
            // ViewBag.SessionName = myName;
            return View("Index"); //add "myName" here to pass to viewmodel
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
