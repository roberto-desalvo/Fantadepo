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
        public static class Values
        {
            public const decimal GOAL = 2;
            public const decimal OWN_GOAL = -1;
            public const decimal ASSIST = 1;
            public const decimal YELLOW_CARD = -0.5m;
            public const decimal RED_CARD = -1.5m;
            public const decimal SCORED_PENALTY = 1;
            public const decimal SCORED_FREE_KICK = 2;
            public const decimal FAILED_PENALTY = -1.5m;
            public const decimal FAILED_FREE_KICK = -0.5m;
            public const decimal SAVED_PENALTY = 2;
            public const decimal SAVED_FREE_KICK = 1;
            public const decimal CONCEDED_GOAL_0 = 10;
            public const decimal CONCEDED_GOAL_1 = 8;
            public const decimal CONCEDED_GOAL_2 = 6;
            public const decimal CONCEDED_GOAL_3 = 4;
            public const decimal CONCEDED_GOAL_4 = 2;
            public const decimal CONCEDED_GOAL_5 = 1;
            public const decimal CONCEDED_GOAL_6 = -1;
            public const decimal CONCEDED_GOAL_7 = -2;
            public const decimal CONCEDED_GOAL_8 = -3;
            public const decimal CONCEDED_GOAL_9 = -4;
            public const decimal CONCEDED_GOAL_10 = -5;
            public const decimal MINIMUM = 0.5m;
        }

        public static decimal GetPerformanceSum(PlayerPerformance performance)
        {
            decimal final = performance.Vote;
            final += performance.Goals * Values.GOAL;
            final += performance.OwnGoals * Values.OWN_GOAL;
            final += performance.Assists * Values.ASSIST;
            final += performance.YellowCards * Values.YELLOW_CARD;
            final += performance.RedCards * Values.RED_CARD;
            final += performance.ScoredPenalties * Values.SCORED_PENALTY;
            final += performance.ScoredFreeKicks * Values.SCORED_FREE_KICK;
            final += performance.FailedPenalties * Values.FAILED_PENALTY;
            final += performance.FailedFreeKicks * Values.FAILED_FREE_KICK;

            if (performance.IsGoalKeeper)
            {         
                final += performance.ConcededGoals switch
                {
                    0 => Values.CONCEDED_GOAL_0,
                    1 => Values.CONCEDED_GOAL_1,
                    2 => Values.CONCEDED_GOAL_2,
                    3 => Values.CONCEDED_GOAL_3,
                    4 => Values.CONCEDED_GOAL_4,
                    5 => Values.CONCEDED_GOAL_5,
                    6 => Values.CONCEDED_GOAL_6,
                    7 => Values.CONCEDED_GOAL_7,
                    8 => Values.CONCEDED_GOAL_8,
                    9 => Values.CONCEDED_GOAL_9,
                    10 => Values.CONCEDED_GOAL_10,
                    _ => Values.CONCEDED_GOAL_10
                };

                final += performance.SavedPenalties * Values.SAVED_PENALTY;
                final += performance.SavedFreeKicks * Values.SAVED_FREE_KICK;
            }

            return final >= Values.MINIMUM ? final : Values.MINIMUM;
        }
    }
}
