using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.DataAccess.Entities
{
    public class SeasonPlayer
    {
        public int Id { get; set; }        
        public int? FirstRole { get; set; }
        public int? SecondaryRole { get; set; }

        public int SeasonId { get; set; }
        public Season Season { get; set; } = new();

        public int PlayerId { get; set; }
        public Player Player { get; set; } = new();

        public ICollection<TeamSeasonPlayer> TeamSeasonPlayers { get; set; } = [];
        public ICollection<PlayerPerformance> Performances { get; set; } = [];
    }
}
