
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Shared.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;

        public ICollection<TeamPlayer>? TeamPlayers { get; set; }
        public ICollection<PlayerPerformance>? PlayerPerformances { get; set; }
    }

}
