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
            //var players = from a in db.PlayerInfo.Take(25)
            //              orderby a.playerValue descending
            //              select a;

            //double sum = 0;
            //foreach (var item in players)
            //{
            //    sum += item.playerValue;


            //}

            //return View(players.ToList());


            //var catchers = from a in db.PlayerInfo.Take(25)
            //               where a.position.ToList() == "C".ToList()
            //               orderby a.playerValue descending
            //               select a;
            //var catchers = db.PlayerInfo.Where(x => x.position == "C").OrderByDescending(y => y.playerValue).Take(2).ToList();

            //var startingPitchers = db.PlayerInfo.Where(x => x.position == "SP").OrderByDescending(y => y.playerValue).Take(5).ToList();

            List<PlayersInfo> catchers = OptimizeCatchers();
            List<PlayersInfo> startingPitchers = OptimizeStartingPitchers();
            List<PlayersInfo> reliefPitchers = OptimizeReliefPitchers();
            List<PlayersInfo> outfielders = OptimizeOutfielders();
            List<PlayersInfo> thirdbasemen = OptimizeThirdBasemen();
            List<PlayersInfo> secondbasemen = OptimizeSecondBasemen();
            List<PlayersInfo> shortstops = OptimizeShortStops();
            List<PlayersInfo> firstbasemen = OptimizeFirstBasemen();


            List<PlayersInfo> players = new List<PlayersInfo>();
            players.AddRange(catchers);
            players.AddRange(startingPitchers);
            players.AddRange(reliefPitchers);
            players.AddRange(outfielders);
            players.AddRange(thirdbasemen);
            players.AddRange(secondbasemen);
            players.AddRange(shortstops);
            players.AddRange(firstbasemen);

            //double sum = 0;
            //foreach (var item in players)
            //{
            //    sum += item.playerValue;


            //}

            return View(players);

            //double sum = 0;
            //foreach (var item in players)
            //{
            //    sum += item.playerValue;


            //}

            //var catchers1 = db.PlayerInfo.Select(x => x.playerValue).ToList();



        }
        public List<PlayersInfo> OptimizeCatchers()
        {
            var catchers = db.PlayerInfo.Where(x => x.position == "C").OrderByDescending(y => y.playerValue).Take(2).ToList();

            //var catchers1 = db.PlayerInfo.Select(x => x.playerValue).ToList();



            return catchers.ToList();
        }
        public List<PlayersInfo> OptimizeStartingPitchers()
        {
            var startingPitchers = db.PlayerInfo.Where(x => x.position == "SP").OrderByDescending(y => y.playerValue).Take(5).ToList();

            return startingPitchers.ToList();
        }
        public List<PlayersInfo> OptimizeReliefPitchers()
        {
            var reliefPitchers = db.PlayerInfo.Where(x => x.position == "RP").OrderByDescending(y => y.playerValue).Take(7).ToList();

            return reliefPitchers.ToList();
        }
        public List<PlayersInfo> OptimizeOutfielders()
        {
            var outfielders = db.PlayerInfo.Where(x => x.position == "OF").OrderByDescending(y => y.playerValue).Take(5).ToList();

            return outfielders.ToList();
        }
        public List<PlayersInfo> OptimizeThirdBasemen()
        {
            var thirdbasemen = db.PlayerInfo.Where(x => x.position == "3B").OrderByDescending(y => y.playerValue).Take(2).ToList();

            return thirdbasemen.ToList();
        }
        public List<PlayersInfo> OptimizeSecondBasemen()
        {
            var secondbasemen = db.PlayerInfo.Where(x => x.position == "2B").OrderByDescending(y => y.playerValue).Take(1).ToList();

            return secondbasemen.ToList();
        }
        public List<PlayersInfo> OptimizeShortStops()
        {
            var shortstops = db.PlayerInfo.Where(x => x.position == "SS").OrderByDescending(y => y.playerValue).Take(2).ToList();

            return shortstops.ToList();
        }
        public List<PlayersInfo> OptimizeFirstBasemen()
        {
            var firstbasemen = db.PlayerInfo.Where(x => x.position == "1B").OrderByDescending(y => y.playerValue).Take(1).ToList();

            return firstbasemen.ToList();
        }
    }
}