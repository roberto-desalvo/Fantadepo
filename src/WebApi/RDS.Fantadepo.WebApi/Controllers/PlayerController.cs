using Microsoft.AspNetCore.Mvc;
using RDS.Fantadepo.Shared.Models;
using RDS.Fantadepo.Shared.Models.SearchCriteria;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;

namespace RDS.Fantadepo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService ?? throw new ArgumentNullException(nameof(playerService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayer(
            [FromQuery] string? firstNamePattern,
            [FromQuery] string? lastNamePattern,
            [FromQuery] string? nickNamePattern,
            [FromQuery] string? include
            )
        {
            try
            {
                var filter = new PlayerSearchCriteria
                {
                    FirstnamePattern = firstNamePattern,
                    LastnamePattern = lastNamePattern,
                    NicknamePattern = nickNamePattern,
                    Include = include
                };

                return Ok(await _playerService.GetPlayers(filter));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            try
            {
                var player = await _playerService.GetPlayer(id);
                return player != null ? Ok(player) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, Player player)
        {
            try
            {
                return await _playerService.UpdatePlayer(id, player) ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            try
            {
                var newId = await _playerService.CreatePlayer(player);
                return CreatedAtAction("GetPlayer", new { id = newId }, player);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            try
            {
                return await _playerService.DeletePlayer(id) ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
