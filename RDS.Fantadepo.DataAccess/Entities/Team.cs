using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.DataAccess.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int CoachId { get; set; }
        public Coach Coach { get; set; } = new();

        public int SeasonId { get; set; }
        public Season Season { get; set; } = new();
        
        public ICollection<TeamSeasonPlayer> TeamSeasonPlayers { get; set; } = [];
        public ICollection<MatchTeam> HomeMatches { get; } = [];
        public ICollection<MatchTeam> AwayMatches { get; } = [];
    }
}
