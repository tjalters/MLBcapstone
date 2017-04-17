using MLBcapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MLBcapstone.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PlayerTable()
        {
            //var catchers = from a in db.PlayerInfo
            //               where a.position == "C"
            //               select a;

            //return View(catchers.ToList());
            //var players = from a in db.PlayerInfo
            //              orderby a.playerValue
            //              select a;

            //return View(players.ToList());
            return View(db.PlayerInfo.ToList());
        }
        public ActionResult OptimizeRoster()
        {
            var players = from a in db.PlayerInfo
                          orderby a.playerValue
                          select a;

            return View(players.ToList());
        }
    }
}