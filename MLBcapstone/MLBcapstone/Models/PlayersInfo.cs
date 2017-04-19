﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MLBcapstone.Models
{
    public class PlayersInfo
    {
        [Key]

        [Display(Name = "Player Name")]
        public string playerName { get; set; }
        public string position { get; set; }
        [Display(Name = "Player Rating")]
        public double playerRating { get; set; }
        public double salary { get; set; }
        [Display(Name = "Player Value")]
        public double playerValue { get; set; }
    }
}