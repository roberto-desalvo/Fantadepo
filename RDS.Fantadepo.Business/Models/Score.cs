using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Models
{
    public class Score
    {
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int OwnGoals { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int ConcededGoals { get; set; } = -1; // distinguish between goalkeeper and others
        public int SavedPenalties { get; set; }
        public int SavedFreeKicks { get; set; }
        public int ScoredPenalties { get; set; }
        public int ScoredFreeKicks { get; set; }
        public int FailedPenalties { get; set; }
        public int FailedFreeKicks { get; set; }
    }
}
