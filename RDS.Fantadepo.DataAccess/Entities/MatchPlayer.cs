using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.DataAccess.Entities
{
    public class MatchTeamPlayer
    {
        public int Id { get; set; }
        public int MatchTeamId { get; set; }
        public MatchTeam MatchTeam { get; set; } = new();
        public int TeamSeasonPlayerId { get; set; }
        public TeamSeasonPlayer TeamSeasonPlayer { get; set; } = new();
    }
}
