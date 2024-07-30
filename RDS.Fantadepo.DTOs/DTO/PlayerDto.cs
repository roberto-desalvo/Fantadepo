
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Models.DTO
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;

        public ICollection<TeamPlayerDto> TeamPlayers { get; set; }
        public ICollection<PlayerPerformanceDto> PlayerPerformances { get; set; }
    }

}
