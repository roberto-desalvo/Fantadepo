﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Models
{
    public class Turn
    {
        public IList<Match> Matches { get; set; }
        public Dictionary<Player, Score> Scores { get; set; }
    }
}
