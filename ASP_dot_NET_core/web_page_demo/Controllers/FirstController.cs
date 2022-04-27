using System;
using Microsoft.AspNetCore.Mvc;

namespace web_page_demo.Controllers
{
    public class FirstController : Controller
    {
        //What type of route are we working with?
        [HttpGet]
        //We tell it what the name of the route is
        //If I leave route with empty quotations, then I am referring to the front page
        [Route("")]
        public ViewResult Index()
        {
            string[] myArray = new string[] {"one", "two", "three"};
            ViewBag.myArray = myArray;
            return View("Index");
        }

        [HttpGet]
        [Route("second")]

        public ViewResult Second()
        {
            ViewBag.myVariable = "This is coming from my viewbag";
            return View("Second");
        }

        [HttpGet("redirect")]
        public RedirectToActionResult Redirect()
        {
            return RedirectToAction("Second");
        }

        [HttpGet("form")]
        public ViewResult Form()
        {
            //if you don't pass anything into View, the controller is going to assume the name of the action (in this case, it's "Form" (on line 35))
            return View();
        }


        //IActionResult is a built in return type where c# be like ok, "i'll render whatever it is you're passing into here"

        //because we don't have a database and we haven't used session yet, JUST FOR THIS LESSON we're going to render on a post request. And viewbags don't persist after redirects, so you can't pass it through that way...
        [HttpPost("submitForm")]
        public IActionResult postForm(string Name, string FavColor, int FavNumber)
        {
            Console.WriteLine($"Name: {Name}, Favorite Color: {FavColor}, Favorite Number: {FavNumber}");
            ViewBag.Name = Name;
            ViewBag.FavColor = FavColor;
            ViewBag.FavNumber = FavNumber;
            return View("Success");
        }

        [HttpGet("Success")]
        public IActionResult Success()
        {
            return View();
        }
    }
} 