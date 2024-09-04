using Microsoft.Extensions.Options;
using RDS.Fantadepo.WebApi.Business.Options;
using RDS.Fantadepo.WebApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Utilities
{
    public static class PerformanceHelper
    {
        public static decimal GetPerformanceSum(PlayerPerformance performance, ScoreOptions options)
        {
            decimal final = performance.Vote;
            final += performance.Goals * options.Goal;
            final += performance.OwnGoals * options.OwnGoal;
            final += performance.Assists * options.Assist;
            final += performance.YellowCards * options.YellowCard;
            final += performance.RedCards * options.RedCard;
            final += performance.ScoredPenalties * options.ScoredPenalty;
            final += performance.ScoredFreeKicks * options.ScoredFreeKick;
            final += performance.FailedPenalties * options.FailedPenalty;
            final += performance.FailedFreeKicks * options.FailedFreeKick;

            if (performance.IsGoalKeeper)
            {
                final += performance.ConcededGoals switch
                {
                    0 => options.ConcededGoals0,
                    1 => options.ConcededGoals1,
                    2 => options.ConcededGoals2,
                    3 => options.ConcededGoals3,
                    4 => options.ConcededGoals4,
                    5 => options.ConcededGoals5,
                    6 => options.ConcededGoals6,
                    7 => options.ConcededGoals7,
                    8 => options.ConcededGoals8,
                    9 => options.ConcededGoals9,
                    10 => options.ConcededGoals10,
                    _ => options.ConcededGoals10
                };

                final += performance.SavedPenalties * options.SavedPenalty;
                final += performance.SavedFreeKicks * options.SavedFreeKick;
            }
            
            performance.Sum = final >= options.Minimum ? final : options.Minimum;

            return performance.Sum;
        }
    }
}
