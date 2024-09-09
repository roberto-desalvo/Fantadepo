using Microsoft.AspNetCore.Mvc;
using RDS.Fantadepo.Shared.Models;
using RDS.Fantadepo.Shared.Models.SearchCriteria;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams(
            [FromQuery(Name = TeamSearchCriteria.QueryParamName.Include)] string? include,
            [FromQuery(Name = TeamSearchCriteria.QueryParamName.SeasonId)] int? seasonId,
            [FromQuery(Name = TeamSearchCriteria.QueryParamName.CoachId)] int? coachId,
            [FromQuery(Name = TeamSearchCriteria.QueryParamName.NamePattern)] string? namePattern
            )
        {
            try
            {
                var filter = new TeamSearchCriteria
                {
                    SeasonId = seasonId,
                    CoachId = coachId,
                    NamePattern = namePattern,
                    Include = include
                };
                var teams =  await _teamService.GetTeams(filter);
                return Ok(teams);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id,
            [FromQuery(Name = TeamSearchCriteria.QueryParamName.Include)] string? include)
        {
            try
            {
                var team = await _teamService.GetTeam(id, include);
                return team != null ? Ok(team) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team Team)
        {
            try
            {
                return await _teamService.UpdateTeam(id, Team) ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team Team)
        {
            try
            {
                var newId = await _teamService.CreateTeam(Team);
                return CreatedAtAction("GetTeam", new { id = newId }, Team);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            try
            {
                return await _teamService.DeleteTeam(id) ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
