using RDS.Fantadepo.WebApi.Business.Services.Abstractions;
using RDS.Fantadepo.WebApi.DataAccess;
using AutoMapper;
using RDS.Fantadepo.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace RDS.Fantadepo.WebApi.Business.Services
{
    public class MatchService : BaseService, IMatchService
    {
        public MatchService(FantadepoContext context, IMapper mapper) : base(context, mapper)
        {
            
        }

        public async Task<bool> CalculateMatch(Match match)
        {
            var fieldedPlayers = _context.FieldedTeamPlayers.Where(x => x.MatchId == match.Id).ToList();

            foreach(var fieldedPlayer in fieldedPlayers)
            {
                var teamPlayer = await _context.TeamPlayers.FirstOrDefaultAsync(x => x.Id == fieldedPlayer.TeamPlayerId);

                if(teamPlayer == null)
                {
                    continue;
                }

                var player = await _context.Players.FirstOrDefaultAsync(x => x.Id == teamPlayer.PlayerId);

                if(player == null)
                {
                    continue;
                }

                var playerPerformance = await _context.PlayerPerformances.FirstOrDefaultAsync(x => x.PlayerId == player.Id && x.TurnId == match.TurnId);

                if(playerPerformance == null)
                {
                    continue;
                }

                if(match.HomeTeam.TeamPlayers.Contains(teamPlayer))
                {
                    match.HomeTeamScore += playerPerformance.Sum;
                }

                if(match.AwayTeam.TeamPlayers.Contains(teamPlayer))
                {
                    match.AwayTeamScore += playerPerformance.Sum;
                }
            }
            
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
