using AutoMapper;
using RDS.Fantadepo.WebApi.Business.Models;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;
using RDS.Fantadepo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDS.Fantadepo.WebApi.Business.Models.DTO;

namespace RDS.Fantadepo.WebApi.Business.Services
{
    public class PerformanceService(FantadepoContext context, IMapper mapper) : BaseService(context, mapper), IPerformanceService
    {
        public static decimal CalculatePerformance(PlayerPerformanceDto performance)
        {
            decimal final = performance.Vote;
            final += performance.Goals * 2;
            final += performance.OwnGoals * -1;
            final += performance.Assists * 1;
            final += (decimal)(performance.YellowCards * -0.5);
            final += (decimal)(performance.RedCards * -1.5);
            final += performance.ScoredPenalties * 1;
            final += performance.ScoredFreeKicks * 2;
            final += (decimal)(performance.FailedPenalties * -1.5);
            final += (decimal)(performance.FailedFreeKicks * -0.5);

            if (performance.IsGoalKeeper)
            {
                final += performance.SavedPenalties * 2;
                final += performance.SavedFreeKicks * 1;

                var concededGoalsScore = performance.ConcededGoals switch
                {
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

                if (performance.ConcededGoals > 10)
                {
                    concededGoalsScore = -5;
                }

                final += concededGoalsScore;
            }

            if(final < (decimal)0.5)
            {
                final = (decimal)0.5;
            }

            performance.Sum = final;

            return final;
        }
    }
}
