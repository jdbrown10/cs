using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomensLeagues = _context.Leagues.Where(w => w.Name.Contains("Women")).ToList();
            ViewBag.HockeyLeagues = _context.Leagues.Where(h => h.Sport.Contains("Hockey")).ToList();
            List<League> AllLeagues = _context.Leagues.ToList();
            List<League> FBLeagues = _context.Leagues.Where(fb => fb.Sport.Contains("Football")).ToList();
            ViewBag.NotFBLeagues = AllLeagues.Except(FBLeagues).ToList();
            ViewBag.Conferences = _context.Leagues.Where(c => c.Name.Contains("Conference")).ToList();
            ViewBag.Atlantic = _context.Leagues.Where(a => a.Name.Contains("Atlantic")).ToList();
            ViewBag.Dallas = _context.Teams.Where(d => d.Location.Contains("Dallas")).ToList();
            ViewBag.Raptors = _context.Teams.Where(n => n.TeamName.Contains("Raptor")).ToList();
            ViewBag.City = _context.Teams.Where(d => d.Location.Contains("City")).ToList();
            ViewBag.NameStartsWithT = _context.Teams.Where(n => n.TeamName.StartsWith("T")).ToList();
            ViewBag.TeamsABCLocation = _context.Teams.OrderBy(l => l.Location).ToList();
            ViewBag.TeamsReverseABCNames = _context.Teams.OrderByDescending(l => l.TeamName).ToList();
            ViewBag.Coopers = _context.Players.Where(k => k.LastName.Contains("Cooper")).ToList();
            ViewBag.Joshuas = _context.Players.Where(j => j.FirstName.Contains("Joshua")).ToList();
            List<Player> AllCoopers = _context.Players.Where(k => k.LastName.Contains("Cooper")).ToList();
            List<Player> AllJoshuas = _context.Players.Where(j => j.FirstName.Contains("Joshua")).ToList();
            ViewBag.CoopersNoJoshuas = AllCoopers.Except(AllJoshuas).ToList();
            ViewBag.AlexsAndWyatts = _context.Players.Where(n => n.FirstName.Contains("Alexander") || n.FirstName.Contains("Wyatt")).ToList();
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}