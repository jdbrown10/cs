using System;
using Microsoft.AspNetCore.Mvc;

namespace Dojo_Survey.Controllers
{
    public class FirstController : Controller
    {
        [HttpGet]
        [Route("")]
        public ViewResult Form()
        {
            return View("Form");
        }

        [HttpPost("submitForm")]
        public IActionResult postForm(string Name, string DojoLocation, string FavoriteLanguage, string Comment)
        {
            ViewBag.Name = Name;
            ViewBag.DojoLocation = DojoLocation;
            ViewBag.FavoriteLanguage = FavoriteLanguage;
            ViewBag.Comment = Comment;
            return View("Display");
        }

        [HttpGet("Display")]
        public IActionResult Display()
        {
            return View();
        }
    }
} 