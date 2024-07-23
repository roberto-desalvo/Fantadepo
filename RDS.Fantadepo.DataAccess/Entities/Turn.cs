﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.DataAccess.Entities
{
    public class Turn
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly Date { get; set; }

        public int SeasonId { get; set; }
        public Season Season { get; set; } = new();

        public ICollection<Match> Matches { get; set; } = [];
        public ICollection<PlayerPerformance> PlayerPerformances { get; set; } = [];
    }
}
