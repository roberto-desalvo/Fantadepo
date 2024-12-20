﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Shared.Models
{
    public class TeamPlayer
    {
        public int Id { get; set; }
        public bool IsFielded { get; set; }
        public int BenchPosition { get; set; }

        public int TeamId { get; set; }
        public Team? Team { get; set; } 

        public int PlayerId { get; set; }
        public Player? Player { get; set; } 

        public PlayerAcquisition? PlayerAcquisition { get; set; }
        public PlayerRelease? PlayerRelease { get; set; }

        public ICollection<FieldedTeamPlayer>? FieldedPlayers { get; set; }

    }
}
