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
            //var newPlayerInfo = from a in db.PlayerInfo
            //                    select a;
            //List<PlayersInfo> originalRoster = newPlayerInfo.ToList();
            //int playersInitialCount = 366;
            //if(originalRoster.Count == playersInitialCount)
            //{
            //    return View(players);
            //}
            //else if(originalRoster.Count == (playersInitialCount -= 25))
            //{
            //    players = OptimizeRosterTwo(players);
            //    return View(players);
            //}
            //double sum = 0;
            //foreach (var item in players)
            //{
            //    sum += item.playerValue;


            //}

            //var catchers1 = db.PlayerInfo.Select(x => x.playerValue).ToList();
            players = OptimizeRosterTwo(players);
            return View(players);

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

        public List<PlayersInfo> OptimizeRosterTwo(List<PlayersInfo> players)
        {
            //var ListOfStartingPitchersExcludingThe1stLineUp = db.PlayerInfo.Where(x => x.position == "SP" && x.position != ).OrderByDescending(y => y.playerValue).Take(5).ToList();

            //foreach (var item in )
            //{
            //    ListOfStartingPitchersExcludingThe1stLineUp = from a in db.PlayerInfo where a != item select a;
            //}
            //return View();
            //var newPlayerInfo = new PlayersInfo();
            //foreach(var item in players)
            //{
            //    newPlayerInfo = from a in db.PlayerInfo

            //}

            var newPlayerInfo = from a in db.PlayerInfo
                                select a;
            var secondTable = newPlayerInfo.ToList();
            //secondTable.RemoveRange(0, 25);
            foreach (var item in players)
            {
                secondTable.Remove(item);
            }
            var catchers = secondTable.Where(x => x.position == "C").OrderByDescending(y => y.playerValue).Skip(2).Take(2).ToList();
            var startingPitchers = secondTable.Where(x => x.position == "SP").OrderByDescending(y => y.playerValue).Skip(5).Take(5).ToList();
            var reliefPitchers = secondTable.Where(x => x.position == "RP").OrderByDescending(y => y.playerValue).Skip(7).Take(7).ToList();
            var outfielders = secondTable.Where(x => x.position == "OF").OrderByDescending(y => y.playerValue).Skip(5).Take(5).ToList();
            var thirdbasemen = secondTable.Where(x => x.position == "3B").OrderByDescending(y => y.playerValue).Skip(2).Take(2).ToList();
            var secondbasemen = secondTable.Where(x => x.position == "2B").OrderByDescending(y => y.playerValue).Skip(1).Take(1).ToList();
            var shortstops = secondTable.Where(x => x.position == "SS").OrderByDescending(y => y.playerValue).Skip(2).Take(2).ToList();
            var firstbasemen = secondTable.Where(x => x.position == "1B").OrderByDescending(y => y.playerValue).Skip(1).Take(1).ToList();

            List<PlayersInfo> nextTierPlayers = new List<PlayersInfo>();
            nextTierPlayers.AddRange(catchers);
            nextTierPlayers.AddRange(startingPitchers);
            nextTierPlayers.AddRange(reliefPitchers);
            nextTierPlayers.AddRange(outfielders);
            nextTierPlayers.AddRange(thirdbasemen);
            nextTierPlayers.AddRange(secondbasemen);
            nextTierPlayers.AddRange(shortstops);
            nextTierPlayers.AddRange(firstbasemen);

            players.AddRange(nextTierPlayers);
            return (players);
            
        }
    }
}