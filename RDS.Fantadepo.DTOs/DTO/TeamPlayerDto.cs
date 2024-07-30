
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Models.DTO
{
    public class TeamPlayerDto
    {
        public int Id { get; set; }
        public bool IsFielded { get; set; }
        public int BenchPosition { get; set; }

        public int TeamId { get; set; }
        public TeamDto Team { get; set; } = new();

        public int PlayerId { get; set; }
        public PlayerDto Player { get; set; } = new();

        public PlayerAcquisitionDto PlayerAcquisition { get; set; }
        public PlayerReleaseDto? PlayerRelease { get; set; }

        public ICollection<FieldedTeamPlayerDto> FieldedPlayers { get; set; }

    }
}
