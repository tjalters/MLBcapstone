using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MLBcapstone.Models
{
    public class PlayersInfo
    {
        [Key]

        public string playerName { get; set; }
        public string position { get; set; }
        public double playerRating { get; set; }
        public double salary { get; set; }
        public double playerValue { get; set; }
    }
}