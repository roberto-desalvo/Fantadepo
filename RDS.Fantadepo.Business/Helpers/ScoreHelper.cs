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
            decimal final = 0;
            final += score.Goals * 2;
            final += score.OwnGoals * -1;
            final += score.Assists * 1;
            final += (decimal)(score.YellowCards * -0.5);
            final += (decimal)(score.RedCards * -1.5);
            final += score.SavedPenalties * 2;
            final += score.SavedFreeKicks * 1;
            final += score.ScoredPenalties * 1;
            final += score.ScoredFreeKicks * 2;
            final += (decimal)(score.FailedPenalties * -1.5);
            final += (decimal)(score.FailedFreeKicks * -0.5);

            var concededGoalsScore = score.ConcededGoals switch
            {
                -1 => 0,
                0 => 10,
                1 => 8,
                2 => 6,
                3 => 4,
                4 => 2,
                5 => 1,
                6 => -1,
                7 => -2,
                8 => -3,
                9 => -4,
                10 => -5,
                _ => 0
            };

            if(score.ConcededGoals > 10)
            {
                concededGoalsScore = -5;
            }

            final += concededGoalsScore;

            if(final < (decimal)0.5)
            {
                final = (decimal)0.5;
            }

            return final;
        }
    }
}
