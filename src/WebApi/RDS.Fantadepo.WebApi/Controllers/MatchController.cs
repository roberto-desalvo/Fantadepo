using Microsoft.AspNetCore.Mvc;
using RDS.Fantadepo.Shared.Models;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;

namespace RDS.Fantadepo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchController(IMatchService coachService)
        {
            _matchService = coachService ?? throw new ArgumentNullException(nameof(coachService));
        }

        [HttpPost("Calculate/{id}")]
        public async Task<ActionResult<Match>> Calculate(int matchId)
        {
            var match = await _matchService.CalculateMatch(matchId);
            return match == null ? BadRequest("Match not found") : Ok(match);
        }
    }
}
