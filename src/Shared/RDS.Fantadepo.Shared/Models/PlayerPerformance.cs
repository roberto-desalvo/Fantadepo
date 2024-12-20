﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Shared.Models
{
    public class PlayerPerformance
    {
        public int Id { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int OwnGoals { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int ConcededGoals { get; set; }
        public int SavedPenalties { get; set; }
        public int SavedFreeKicks { get; set; }
        public int ScoredPenalties { get; set; }
        public int ScoredFreeKicks { get; set; }
        public int FailedPenalties { get; set; }
        public int FailedFreeKicks { get; set; }
        public bool IsGoalKeeper { get; set; }
        public decimal Vote { get; set; }
        public decimal Sum { get; set; }

        public int PlayerId { get; set; }
        public Player? Player { get; set; }

        public int TurnId { get; set; }
        public Turn? Turn { get; set; }
    }
}
