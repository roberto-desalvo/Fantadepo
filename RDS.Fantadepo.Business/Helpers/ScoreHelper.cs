using RDS.Fantadepo.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Helpers
{
    public static class ScoreHelper
    {
        public static decimal GetFinalScore(Score score)
        {
            var final = 0;
            final += score.Goals * ;
            final += score.OwnGoals * ;
            final += score.Assists * ;
            final += score.YellowCards * ;
            final += score.RedCards * ;
            final += score.ConcededGoals * ;
            final += score.SavedPenalties * ;
            final += score.SavedFreeKicks * ;
            final += score.ScoredPenalties * ;
            final += score.ScoredFreeKicks * ;
            final += score.FailedPenalties * ;
            final += score.FailedFreeKicks * ;
            return final;
        }
    }
}
