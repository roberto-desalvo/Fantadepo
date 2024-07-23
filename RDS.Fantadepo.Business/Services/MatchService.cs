using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RDS.Fantadepo.Business.Models;
using RDS.Fantadepo.Business.Services.Abstractions;
using RDS.Fantadepo.DataAccess;
using Entities = RDS.Fantadepo.DataAccess.Entities;

namespace RDS.Fantadepo.Business.Services
{
    public class MatchService(FantadepoContext context, IMapper mapper) : BaseService(context, mapper), IMatchService
    {
        public bool IsDraw(Match match, IList<PlayerPerformance> performances)
        {
            return CalculateMatch(match, performances) == null;
        }

        public Match CalculateMatch(Match match, IList<PlayerPerformance> performances)
        {
            match.HomeTeamScore = GetTeamScore(match.HomeTeamId, performances);
            match.AwayTeamScore = GetTeamScore(match.AwayTeamId, performances);

            return match;
        }

        public decimal GetTeamScore(int teamId, IEnumerable<PlayerPerformance> performances)
        {            
            var team = _context.Teams.Find(teamId);

            if(team == null)
            {
                return 0; 
            }

            return performances
                .Where(x => team.TeamSeasonPlayers.Where(x => x.IsActive).Select(x => x.SeasonPlayerId).Contains(x.SeasonPlayerId))
                .Sum(GetScoreAsDecimal);
        }

        public static decimal GetScoreAsDecimal(PlayerPerformance performance)
        {
            decimal final = 0;
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

            return final < (decimal)0.5 ? (decimal)0.5 : final;
        }
    }
}
