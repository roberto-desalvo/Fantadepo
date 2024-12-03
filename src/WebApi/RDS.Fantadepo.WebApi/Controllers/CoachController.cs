using Microsoft.AspNetCore.Mvc;
using RDS.Fantadepo.Shared.Models;
using RDS.Fantadepo.Shared.SearchCriteria;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;

namespace RDS.Fantadepo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly ICoachService _coachService;

        public CoachController(ICoachService coachService)
        {
            _coachService = coachService ?? throw new ArgumentNullException(nameof(coachService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coach>>> GetCoaches(
            [FromQuery(Name = CoachSearchCriteria.QueryParamName.TeamId)] int? teamId,
            [FromQuery(Name = CoachSearchCriteria.QueryParamName.FirstNamePattern)] string? firstNamePattern,
            [FromQuery(Name = CoachSearchCriteria.QueryParamName.LastNamePattern)] string? lastNamePattern,
            [FromQuery(Name = CoachSearchCriteria.QueryParamName.Include)] string? include
            )
        {
            try
            {
                var filter = new CoachSearchCriteria
                {
                    TeamId = teamId,
                    FirstNamePattern = firstNamePattern,
                    LastNamePattern = lastNamePattern,
                    Include = include
                };

                return Ok(await _coachService.GetCoaches(filter));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<Coach>> GetCoach(int id)
        {
            try
            {
                var coach = await _coachService.GetCoach(id);
                return coach != null ? Ok(coach) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoach(int id, Coach coach)
        {
            try
            {
                return await _coachService.UpdateCoach(id, coach) ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Coach>> PostCoach(Coach coach)
        {
            try
            {
                var newId = await _coachService.CreateCoach(coach);
                return CreatedAtAction("GetCoach", new { id = newId }, coach);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoach(int id)
        {
            try
            {
                return await _coachService.DeleteCoach(id) ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
