using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUD_demo.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_demo.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //Do a query for all my pets

            ViewBag.AllPets = _context.Pets.OrderBy(d => d.Name).ToList();

            return View();
        }

        [HttpPost("pets/add")]
        public IActionResult AddPet(Pet newPet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newPet); //this is all you have to do to add something to the DB!
                _context.SaveChanges(); //don't forget this part!!
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("pets/remove/{PetId}")]
        public IActionResult RemovePet(int PetId)
        {
            Pet PetToRemove = _context.Pets.SingleOrDefault(s => s.PetId == PetId);
            _context.Pets.Remove(PetToRemove);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("pets/edit/{PetId}")]
        public IActionResult EditPet(int PetId)
        {
            Pet PetToUpdate = _context.Pets.FirstOrDefault(a => a.PetId == PetId);
            return View(PetToUpdate);
        }

        [HttpPost("pets/update/{PetId}")]
        public IActionResult UpdatePet(int PetId, Pet updatedPet)
        {

            if (ModelState.IsValid)
            {
                Pet OldPet = _context.Pets.FirstOrDefault(a => a.PetId == PetId);
                OldPet.Name = updatedPet.Name;
                OldPet.Species = updatedPet.Species;
                OldPet.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditPet", updatedPet);
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
