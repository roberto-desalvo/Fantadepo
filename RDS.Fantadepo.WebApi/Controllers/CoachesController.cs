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
            //var entities = await _context.Coaches.ToListAsync();
            //return Ok(entities.Select(_mapper.Map<IEnumerable<Coach>>));
            return Ok(await _coachService.GetCoaches());
        }

        // GET: api/Coaches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coach>> GetCoach(int id)
        {
            var coach = await  _coachService.GetCoach(id);
            return coach == null ? NotFound() : Ok(coach);
            //var coach = await _context.Coaches.FindAsync(id);

            //if (coach == null)
            //{
            //    return NotFound();
            //}

            //return Ok(_mapper.Map<Coach>(coach));
        }

        // PUT: api/Coaches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoach(int id, Coach coach)
        {
            if (id != coach.Id)
            {
                return BadRequest();
            }

            var updated = await _coachService.UpdateCoach(id, coach);
            return Ok(updated);
            //var entity = _mapper.Map<DataAccess.Entities.Coach>(coach);

            //_context.Entry(entity).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!CoachExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

        // POST: api/Coaches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Coach>> PostCoach(Coach coach)
        {
            var newId = await _coachService.CreateCoach(coach);
            //var entity = _mapper.Map<DataAccess.Entities.Coach>(coach);
            //_context.Coaches.Add(entity);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoach", new { id = newId }, coach);
        }

        // DELETE: api/Coaches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoach(int id)
        {
            return await _coachService.DeleteCoach(id) ? NoContent() : NotFound();
            //var coach = await _context.Coaches.FindAsync(id);
            //if (coach == null)
            //{
            //    return NotFound();
            //}
            //var entity = _mapper.Map<DataAccess.Entities.Coach>(coach);
            //_context.Coaches.Remove(entity);
            //await _context.SaveChangesAsync();

            //return NoContent();
        }

        //private bool CoachExists(int id)
        //{
        //    return _context.Coaches.Any(e => e.Id == id);
        //}
    }
}
