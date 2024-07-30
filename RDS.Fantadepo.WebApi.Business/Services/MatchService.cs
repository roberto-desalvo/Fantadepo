
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;
using RDS.Fantadepo.WebApi.DataAccess;
using RDS.Fantadepo.Models.Models;
using AutoMapper;

namespace RDS.Fantadepo.WebApi.Business.Services
{
    public class MatchService(FantadepoContext context, IMapper mapper) : BaseService(context, mapper), IMatchService
    {
        public bool IsDraw(Match match, IList<PlayerPerformance> performances)
        {
            return CalculateMatch(match, performances) == null;
        }

        public Match CalculateMatch(Match match, IList<PlayerPerformance> performances)
        {
            //match.HomeTeamScore = GetTeamScore(match.HomeTeamSeasonId, performances);
            //match.AwayTeamScore = GetTeamScore(match.AwayTeamSeasonId, performances);

            return match;
        }

        public decimal GetTeamScore(int teamSeasonId, IEnumerable<PlayerPerformance> performances)
        {            
            //var team = _context.TeamSeasons.Find(teamSeasonId);

            //if(team == null)
            //{
            //    return 0; 
            //}

            return 0;
            //return performances
            //    .Where(x => team.TeamPlayers.Where(x => x.IsActive).Select(x => x.SeasonPlayerId).Contains(x.SeasonPlayerId))
            //    .Sum(PerformanceService.CalculatePerformance);
        }

    }
}
