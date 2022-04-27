using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using wedding_planner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace wedding_planner.Controllers
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
                //check if email is already in database
                if(_context.Users.Any(a => a.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View ("Index");
                }
                //hash the password
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                newUser.Password = hasher.HashPassword(newUser, newUser.Password);

                //add the new user
                _context.Users.Add(newUser);
                _context.SaveChanges();

                //set up session
                HttpContext.Session.SetInt32("UserId", newUser.UserId);

                //return redirect
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
                //Go find the user
                User userInDb = _context.Users.FirstOrDefault(a => a.Email == loggedIn.LoginEmail);
                if(userInDb == null)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid login attempt");
                    return View("Index");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(loggedIn, userInDb.Password, loggedIn.LoginPassword);
                if(result == 0)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid login attempt");
                    return View("Index");
                }
                //set up session
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                return RedirectToAction("Dashboard");
            } else{
                return View("Index");
            }
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            //set up session credential
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.LoggedIn = _context.Users.Include(s => s.WeddingsPlanned).FirstOrDefault(a => a.UserId == HttpContext.Session.GetInt32("UserId"));
            ViewBag.AllWeddings = _context.Weddings.Include(a => a.Planner).ToList();
            return View();
        }

        [HttpGet("weddings/add")]
        public IActionResult AddWedding()
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGetAttribute("wedding/{wedId}")]
        public IActionResult OneWedding(int wedId)
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Wedding = _context.Weddings.Include(g => g.GuestRSVPs).ThenInclude(s => s.Attendee).FirstOrDefault(a => a.WeddingId == wedId);
            return View();
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost("weddings/new")]
        public IActionResult NewWedding(Wedding newWedding)
        {
            if (ModelState.IsValid)
            {
                newWedding.UserId = (int)HttpContext.Session.GetInt32("UserId");
                _context.Weddings.Add(newWedding);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            } else {
                return View("AddWedding");
            }
        }

        [HttpPost("rsvp/{wedId}")]
        public IActionResult createRSVP(int wedId)
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index");
            }
            Wedding wedding = _context.Weddings.FirstOrDefault(a => a.WeddingId == wedId);
            RSVP newRSVP = new RSVP{UserId = (int)HttpContext.Session.GetInt32("UserId"), WeddingId = wedId};
            _context.RSVPs.Add(newRSVP);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        [HttpPost("unrsvp/{wedId}")]
        public IActionResult unRSVP(int wedId)
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index");
            }
            RSVP RSVPToDelete = _context.RSVPs.FirstOrDefault(a => a.WeddingId == wedId && a.UserId == (int)HttpContext.Session.GetInt32("UserId"));
            _context.RSVPs.Remove(RSVPToDelete);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("delete/{wedId}")]
        public IActionResult deleteWedding(int wedId)
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index");
            }
            Wedding weddingToDelete = _context.Weddings.FirstOrDefault(a => a.WeddingId == wedId);
            _context.Weddings.Remove(weddingToDelete);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
