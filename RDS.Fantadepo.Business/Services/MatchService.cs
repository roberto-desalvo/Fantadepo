using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RDS.Fantadepo.WebApi.Business.Models;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;
using RDS.Fantadepo.DataAccess;
using Entities = RDS.Fantadepo.DataAccess.Entities;
using RDS.Fantadepo.WebApi.Business.Models.DTO;

namespace RDS.Fantadepo.WebApi.Business.Services
{
    public class MatchService(FantadepoContext context, IMapper mapper) : BaseService(context, mapper), IMatchService
    {
        public bool IsDraw(MatchDto match, IList<PlayerPerformanceDto> performances)
        {
            return CalculateMatch(match, performances) == null;
        }

        public MatchDto CalculateMatch(MatchDto match, IList<PlayerPerformanceDto> performances)
        {
            //match.HomeTeamScore = GetTeamScore(match.HomeTeamSeasonId, performances);
            //match.AwayTeamScore = GetTeamScore(match.AwayTeamSeasonId, performances);

            return match;
        }

        public decimal GetTeamScore(int teamSeasonId, IEnumerable<PlayerPerformanceDto> performances)
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
