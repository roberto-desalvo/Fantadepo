using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Models
{
    public class MatchResult
    {
        public Match Match { get; set; }
        public Team Winner { get; set; }
        public decimal WinnerScore { get; set; }
        public decimal LoserScore { get; set; }
    }
}
