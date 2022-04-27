using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dojo_Survey_With_Validation.Models;

namespace Dojo_Survey_With_Validation.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public ViewResult Form()
        {
            return View("Index");
        }

        [HttpPost("postForm")]
        public IActionResult postForm(User newUser)
        {
            
            if(ModelState.IsValid)
            {
            Console.WriteLine(newUser.Name);
            return View("Display", newUser); //you only have room to pass ONE thing along-- we couldn't use viewbag to pass three things before, but now that we have a User class, we can pass through that one class which contains all of the data we want
            } else {
                return View("Index");
            }
        }

        [HttpGet("Display")]
        public IActionResult Display()
        {
            return View();
        }
    }
} 