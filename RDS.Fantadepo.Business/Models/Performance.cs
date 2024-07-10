using RDS.Fantadepo.Business.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Models
{
    public class Performance
    {
        public Player Player { get; set; }
        public Score Score { get; set; }
        public decimal DecimalScore { get => ScoreHelper.GetFinalScore(Score); }
    }
}
