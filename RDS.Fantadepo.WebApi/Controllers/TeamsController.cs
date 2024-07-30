using Microsoft.AspNetCore.Mvc;
using RDS.Fantadepo.Models.Models;
using RDS.Fantadepo.WebApi.Business.Services;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;
using RDS.Fantadepo.WebApi.Business.Utilities.Extensions;

namespace RDS.Fantadepo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService ?? throw new ArgumentNullException(nameof(teamService));
        }

        // GET: api/Teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams([FromQuery] int? seasonId, [FromQuery] bool? withCoaches)
        {
            var filter = seasonId.IsNullOrZero() ? null : TeamFilters.TeamBySeason(seasonId!.Value);
            var teams = await (withCoaches.IsTrue() ? _teamService.GetTeamsWithCoaches(filter) : _teamService.GetTeams(filter));
            return Ok(teams);
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id, [FromQuery] bool? withCoach)
        {
            var team = await (withCoach.IsTrue() ? _teamService.GetTeam(id) : _teamService.GetTeamWithCoach(id));
            return team != null ? Ok(team) : NotFound();
        }

        // PUT: api/Teams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team Team)
        {
            return await _teamService.UpdateTeam(id, Team) ? Ok() : BadRequest();
        }

        // POST: api/Teams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team Team)
        {
            var newId = await _teamService.CreateTeam(Team);
            return CreatedAtAction("GetTeam", new { id = newId }, Team);
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            return await _teamService.DeleteTeam(id) ? NoContent() : NotFound();
        }
    }
}
