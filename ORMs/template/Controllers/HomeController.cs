using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using template.Models;
using Microsoft.AspNetCore.Http;

namespace template.Controllers
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
            return View();
        }

        [HttpPost("users/add")]
        public IActionResult AddUser(User newUser)
        {
            if(ModelState.IsValid)
            {
                //set up session
                return RedirectToAction("Dashboard");
            } else{
                return View("Index");
            }
        }

        [HttpPost("users/login")]
        public IActionResult LoginUser(LoginUser loggedIn)
        {
            if(ModelState.IsValid)
            {
                //set up session
                return RedirectToAction("Dashboard");
            } else{
                return View("Index");
            }
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            //set up session credential
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
