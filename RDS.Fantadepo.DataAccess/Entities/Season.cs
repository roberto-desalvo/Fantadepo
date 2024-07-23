using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.DataAccess.Entities
{
    public class Season
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Team> Teams { get; set; } = [];
        public ICollection<SeasonPlayer> SeasonPlayers { get; set; } = [];
        public ICollection<Turn> Turns { get; set; } = [];
    }
}
