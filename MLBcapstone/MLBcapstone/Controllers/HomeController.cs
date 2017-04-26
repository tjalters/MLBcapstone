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
        //private List<PlayersInfo> SecondTierPlayers;

        //private List<PlayersInfo> SecondTierPlayers;

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
        public ActionResult SortBySalary()
        {
            //var players = from a in db.PlayerInfo.Take(25)
            //              orderby a.playerRating descending
                          
            return View();
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

            //return View(players.ToList())

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

            //players = OptimizeRosterThree(players);
            //OptimizeRosterTwo();
            return View(players);

        }
        public List<PlayersInfo> OptimizeCatchers()
        {
            var catchers = db.PlayerInfo.Where(x => x.position == "C").OrderByDescending(y => y.playerValue).Take(2).ToList();

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
            var firstbasemen = db.PlayerInfo.Where(x => x.position == "1B").OrderByDescending(y => y.playerRating).Take(1).ToList();

            return firstbasemen.ToList();
        }

        public ActionResult OptimizeRosterTwo()
        {

            //var newPlayerInfo = new PlayersInfo();
            //foreach(var item in players)
            //{
            //    newPlayerInfo = from a in db.PlayerInfo

            //}

            var newPlayerInfo = from a in db.PlayerInfo
                                select a;
            var secondRoster = newPlayerInfo.ToList();
            //secondTable.RemoveRange(0, 25);
            //foreach (var item in players)
            //{
            //    secondRoster.Remove(item);
            //}
            var catchers = secondRoster.Where(x => x.position == "C").OrderByDescending(y => y.playerValue).Skip(2).Take(2).ToList();
            var startingPitchers = secondRoster.Where(x => x.position == "SP").OrderByDescending(y => y.playerValue).Skip(5).Take(5).ToList();
            var reliefPitchers = secondRoster.Where(x => x.position == "RP").OrderByDescending(y => y.playerValue).Skip(7).Take(7).ToList();
            var outfielders = secondRoster.Where(x => x.position == "OF").OrderByDescending(y => y.playerValue).Skip(5).Take(5).ToList();
            var thirdbasemen = secondRoster.Where(x => x.position == "3B").OrderByDescending(y => y.playerValue).Skip(2).Take(2).ToList();
            var secondbasemen = secondRoster.Where(x => x.position == "2B").OrderByDescending(y => y.playerValue).Skip(1).Take(1).ToList();
            var shortstops = secondRoster.Where(x => x.position == "SS").OrderByDescending(y => y.playerValue).Skip(2).Take(2).ToList();
            var firstbasemen = secondRoster.Where(x => x.position == "1B").OrderByDescending(y => y.playerValue).Skip(1).Take(1).ToList();

            List<PlayersInfo> SecondTierPlayers = new List<PlayersInfo>();
            SecondTierPlayers.AddRange(catchers);
            SecondTierPlayers.AddRange(startingPitchers);
            SecondTierPlayers.AddRange(reliefPitchers);
            SecondTierPlayers.AddRange(outfielders);
            SecondTierPlayers.AddRange(thirdbasemen);
            SecondTierPlayers.AddRange(secondbasemen);
            SecondTierPlayers.AddRange(shortstops);
            SecondTierPlayers.AddRange(firstbasemen);

            SecondTierPlayers.AddRange(SecondTierPlayers);
            return View("OptimizeRosterTwo", SecondTierPlayers);
            
        }
        public ActionResult OptimizeRosterThree()
        {
            var rosterThreeInfo = from a in db.PlayerInfo
                                select a;
            var ThirdRoster = rosterThreeInfo.ToList();
            //secondTable.RemoveRange(0, 25);
            //List<PlayersInfo> firstSecondCombo = new List<PlayersInfo>();
            //firstSecondCombo.AddRange(players);
            //firstSecondCombo.AddRange(SecondTierRoster);


            //foreach (var item in firstSecondCombo)
            //{
            //    ThirdRoster.Remove(item);
            //}
            var catchers = ThirdRoster.Where(x => x.position == "C").OrderByDescending(y => y.playerValue).Skip(4).Take(2).ToList();
            var startingPitchers = ThirdRoster.Where(x => x.position == "SP").OrderByDescending(y => y.playerValue).Skip(10).Take(5).ToList();
            var reliefPitchers = ThirdRoster.Where(x => x.position == "RP").OrderByDescending(y => y.playerValue).Skip(14).Take(7).ToList();
            var outfielders = ThirdRoster.Where(x => x.position == "OF").OrderByDescending(y => y.playerValue).Skip(10).Take(5).ToList();
            var thirdbasemen = ThirdRoster.Where(x => x.position == "3B").OrderByDescending(y => y.playerValue).Skip(4).Take(2).ToList();
            var secondbasemen = ThirdRoster.Where(x => x.position == "2B").OrderByDescending(y => y.playerValue).Skip(2).Take(1).ToList();
            var shortstops = ThirdRoster.Where(x => x.position == "SS").OrderByDescending(y => y.playerValue).Skip(4).Take(2).ToList();
            var firstbasemen = ThirdRoster.Where(x => x.position == "1B").OrderByDescending(y => y.playerValue).Skip(2).Take(1).ToList();

            List<PlayersInfo> ThirdTierPlayers = new List<PlayersInfo>();
            ThirdTierPlayers.AddRange(catchers);
            ThirdTierPlayers.AddRange(startingPitchers);
            ThirdTierPlayers.AddRange(reliefPitchers);
            ThirdTierPlayers.AddRange(outfielders);
            ThirdTierPlayers.AddRange(thirdbasemen);
            ThirdTierPlayers.AddRange(secondbasemen);
            ThirdTierPlayers.AddRange(shortstops);
            ThirdTierPlayers.AddRange(firstbasemen);

            ThirdTierPlayers.AddRange(ThirdTierPlayers);
            return View("OptimizeRosterThree", ThirdTierPlayers);
        }

        public ActionResult OptimizeRosterFour()
        {
            var rosterFourInfo = from a in db.PlayerInfo
                                  select a;
            var FourthRoster = rosterFourInfo.ToList();
            //secondTable.RemoveRange(0, 25);
            //List<PlayersInfo> firstSecondCombo = new List<PlayersInfo>();
            //firstSecondCombo.AddRange(players);
            //firstSecondCombo.AddRange(SecondTierRoster);


            //foreach (var item in firstSecondCombo)
            //{
            //    ThirdRoster.Remove(item);
            //}
            var catchers = FourthRoster.Where(x => x.position == "C").OrderByDescending(y => y.playerValue).Skip(4).Take(2).ToList();
            var startingPitchers = FourthRoster.Where(x => x.position == "SP").OrderByDescending(y => y.playerValue).Skip(10).Take(5).ToList();
            var reliefPitchers = FourthRoster.Where(x => x.position == "RP").OrderByDescending(y => y.playerValue).Skip(14).Take(7).ToList();
            var outfielders = FourthRoster.Where(x => x.position == "OF").OrderByDescending(y => y.playerValue).Skip(10).Take(5).ToList();
            var thirdbasemen = FourthRoster.Where(x => x.position == "3B").OrderByDescending(y => y.playerValue).Skip(4).Take(2).ToList();
            var secondbasemen = FourthRoster.Where(x => x.position == "2B").OrderByDescending(y => y.playerValue).Skip(2).Take(1).ToList();
            var shortstops = FourthRoster.Where(x => x.position == "SS").OrderByDescending(y => y.playerValue).Skip(4).Take(2).ToList();
            var firstbasemen = FourthRoster.Where(x => x.position == "1B").OrderByDescending(y => y.playerValue).Skip(2).Take(1).ToList();

            List<PlayersInfo> FourthTierPlayers = new List<PlayersInfo>();
            FourthTierPlayers.AddRange(catchers);
            FourthTierPlayers.AddRange(startingPitchers);
            FourthTierPlayers.AddRange(reliefPitchers);
            FourthTierPlayers.AddRange(outfielders);
            FourthTierPlayers.AddRange(thirdbasemen);
            FourthTierPlayers.AddRange(secondbasemen);
            FourthTierPlayers.AddRange(shortstops);
            FourthTierPlayers.AddRange(firstbasemen);

            FourthTierPlayers.AddRange(FourthTierPlayers);
            return View("OptimizeRosterFour", FourthTierPlayers);
        }



        public ActionResult OptimizeRosterBasedOnPlayerRating()
        {
            //var players = from a in db.PlayerInfo.Take(25)
            //              orderby a.playerValue descending
            //              select a;

            //double sum = 0;
            //foreach (var item in players)
            //{
            //    sum += item.playerValue;


            //}+

            //return View(players.ToList())

            List<PlayersInfo> catchers = OptimizeCatchersByRating();
            List<PlayersInfo> startingPitchers = OptimizeStartingPitchersByRating();
            List<PlayersInfo> reliefPitchers = OptimizeReliefPitchersByRating();
            List<PlayersInfo> outfielders = OptimizeOutfieldersByRating();
            List<PlayersInfo> thirdbasemen = OptimizeThirdBasemenByRating();
            List<PlayersInfo> secondbasemen = OptimizeSecondBasemenByRating();
            List<PlayersInfo> shortstops = OptimizeShortStopsByRating();
            List<PlayersInfo> firstbasemen = OptimizeFirstBasemenByRating();


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

            //players = OptimizeRosterThree(players);
            //OptimizeRosterTwo();
            return View(players);

        }
        public List<PlayersInfo> OptimizeCatchersByRating()
        {
            var catchers = db.PlayerInfo.Where(x => x.position == "C").OrderByDescending(y => y.playerRating).Take(2).ToList();

            return catchers.ToList();
        }
        public List<PlayersInfo> OptimizeStartingPitchersByRating()
        {
            var startingPitchers = db.PlayerInfo.Where(x => x.position == "SP").OrderByDescending(y => y.playerRating).Take(5).ToList();

            return startingPitchers.ToList();
        }
        public List<PlayersInfo> OptimizeReliefPitchersByRating()
        {
            var reliefPitchers = db.PlayerInfo.Where(x => x.position == "RP").OrderByDescending(y => y.playerRating).Take(7).ToList();

            return reliefPitchers.ToList();
        }
        public List<PlayersInfo> OptimizeOutfieldersByRating()
        {
            var outfielders = db.PlayerInfo.Where(x => x.position == "OF").OrderByDescending(y => y.playerRating).Take(5).ToList();

            return outfielders.ToList();
        }
        public List<PlayersInfo> OptimizeThirdBasemenByRating()
        {
            var thirdbasemen = db.PlayerInfo.Where(x => x.position == "3B").OrderByDescending(y => y.playerRating).Take(2).ToList();

            return thirdbasemen.ToList();
        }
        public List<PlayersInfo> OptimizeSecondBasemenByRating()
        {
            var secondbasemen = db.PlayerInfo.Where(x => x.position == "2B").OrderByDescending(y => y.playerRating).Take(1).ToList();

            return secondbasemen.ToList();
        }
        public List<PlayersInfo> OptimizeShortStopsByRating()
        {
            var shortstops = db.PlayerInfo.Where(x => x.position == "SS").OrderByDescending(y => y.playerRating).Take(2).ToList();

            return shortstops.ToList();
        }
        public List<PlayersInfo> OptimizeFirstBasemenByRating()
        {
            var firstbasemen = db.PlayerInfo.Where(x => x.position == "1B").OrderByDescending(y => y.playerRating).Take(1).ToList();

            return firstbasemen.ToList();
        }
    }
}