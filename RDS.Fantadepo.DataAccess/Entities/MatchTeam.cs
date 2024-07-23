using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.DataAccess.Entities
{
    public class MatchTeam
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; } = new();
        public int MatchId { get; set; }
        public Match Match { get; set; } = new();
        public ICollection<MatchTeamPlayer> MatchTeamPlayers { get; set; } = [];
    }
}
