using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using login_and_registration.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace login_and_registration.Controllers
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
            return View();
        }

        [HttpGet("/login")]

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("users/create")]
        public IActionResult CreateUser(User newUser)
        {
            if(ModelState.IsValid)
            {
                //make sure e-mail isn't already in the DB
                if(_context.Users.Any(s => s.Email == newUser.Email))
                {
                    //if we find the email in the DB already... send an error message
                    ModelState.AddModelError("Email", "Email already in use.");
                    return View("Index");
                }

                //Hash PW before you go into DB, but after validating. It's gotta happen right here.
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                _context.Add(newUser);
                _context.SaveChanges();
                //set up a session
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                return RedirectToAction("Success");
            } else {
                return View("Index");
            }
        }

        [HttpPost("users/login")]
        public IActionResult Login(LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {
                User userInDb = _context.Users.FirstOrDefault(d => d.Email == loginUser.LogEmail);
                if (userInDb == null)
                {
                    ModelState.AddModelError("LogEmail", "Invalid Email/Password");
                    return View("Login");
                }
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(loginUser, userInDb.Password, loginUser.LogPassword);

                if(result == 0)
                {
                    ModelState.AddModelError("LogEmail", "Invalid Email/Password");
                    return View("Login");
                }
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                return RedirectToAction("Success");
            } else
            {
                return View("Login");
            }
            //find user based on email


        }

        [HttpGet("Success")]
        public IActionResult Success()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index");
            }
            User LoggedInUser = _context.Users.FirstOrDefault(a => a.UserId == (int) HttpContext.Session.GetInt32("UserId"));
            return View(LoggedInUser);
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
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
