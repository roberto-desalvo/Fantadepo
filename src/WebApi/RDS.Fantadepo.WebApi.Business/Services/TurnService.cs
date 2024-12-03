using AutoMapper;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;
using RDS.Fantadepo.WebApi.DataAccess;
using Entities = RDS.Fantadepo.WebApi.DataAccess.Entities;
using RDS.Fantadepo.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace RDS.Fantadepo.WebApi.Business.Services
{
    public class TurnService : BaseService, ITurnService
    {
        private readonly IPerformanceService _performanceService;
        private readonly IMatchService _matchService;

        public TurnService(FantadepoContext context, IMapper mapper, IPerformanceService performanceService, IMatchService matchService) : base(context, mapper)
        {
            _performanceService = performanceService ?? throw new System.ArgumentNullException(nameof(performanceService));
            _matchService = matchService ?? throw new System.ArgumentNullException(nameof(matchService));

        }

        public async Task<bool> CalculateTurn(int turnId, IList<PlayerPerformance> performances)
        {            
            var turn = await _context.Turns.FirstOrDefaultAsync(x => x.Id == turnId);

            if(turn == null)
            {
                return false;
            }

            turn.PlayerPerformances = _mapper.Map<IList<Entities.PlayerPerformance>>(performances);
            await _context.SaveChangesAsync();

            foreach(var performance in performances)
            {
                await _performanceService.CalculatePerformanceSum(performance.Id);
            }

            foreach(var match in turn.Matches)
            {
                await _matchService.CalculateMatch(match.Id);
            }
            return true;
        }
    }
}
