using Microsoft.AspNetCore.Mvc;
using RDS.Fantadepo.Models.Models;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;

namespace RDS.Fantadepo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachesController : ControllerBase
    {
        private readonly ICoachService _coachService;

        public CoachesController(ICoachService coachService)
        {
            _coachService = coachService ?? throw new ArgumentNullException(nameof(coachService));
        }

        // GET: api/Coaches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coach>>> GetCoaches()
        {
            try
            {
                return Ok(await _coachService.GetCoaches());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Coaches/5
        [HttpGet("{id}")]
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

        // PUT: api/Coaches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // POST: api/Coaches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // DELETE: api/Coaches/5
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
