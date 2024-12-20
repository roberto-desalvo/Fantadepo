﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Shared.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int CoachId { get; set; }
        public Coach? Coach { get; set; }

        public int SeasonId { get; set; }
        public Season? Season { get; set; }

        public ICollection<Match>? HomeMatches { get; set; }
        public ICollection<Match>? AwayMatches { get; set; }
        public ICollection<TeamPlayer>? TeamPlayers { get; set; }
    }
}
