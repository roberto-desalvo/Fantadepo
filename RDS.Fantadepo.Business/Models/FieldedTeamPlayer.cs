using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Models
{
    public class FieldedTeamPlayer
    {
        public int Id { get; set; }
        public int TeamPlayerId { get; set; }
        public TeamPlayer TeamPlayer { get; set; } = new();
        public int MatchId { get; set; }
        public Match Match { get; set; } = new();
    }
}
