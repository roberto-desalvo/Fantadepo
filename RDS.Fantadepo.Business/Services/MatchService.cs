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
