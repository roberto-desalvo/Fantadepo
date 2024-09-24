using Microsoft.AspNetCore.Mvc;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;

namespace RDS.Fantadepo.WebApi.Controllers
{
    [Controller]
    [Route("/[controller]/import")]
    public class OperationController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly ITeamService _teamService;

        public OperationController(IPlayerService playerService, ITeamService teamService)
        {
            _playerService = playerService ?? throw new ArgumentNullException(nameof(playerService));
            _teamService = teamService ?? throw new ArgumentNullException(nameof(teamService));
        }

        [HttpPost("rosters")]
        public async Task<IActionResult> Operation()
        {
            //var path = "C:\\github\\Fantadepo\\resources\\seasons\\2023-24\\Rose iniziali.xlsx";
            var path = "C:\\git_personal\\Fantadepo\\resources\\seasons\\2023-24\\Rose iniziali.xlsx";

            await _playerService.ImportPlayersFromRosterFile(path);
            await _teamService.ImportTeamsWithCoachesFromRosterFile(path);

            return Ok();
        }
    }
}
