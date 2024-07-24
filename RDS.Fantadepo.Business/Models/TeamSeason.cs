using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Models
{
    public class TeamSeason
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; } = new();
        public int SeasonId { get; set; }
        public Season Season { get; set; } = new();

        public ICollection<TeamPlayer> TeamPlayers { get; set; } = [];
        public ICollection<Match> HomeMatches { get; } = [];
        public ICollection<Match> AwayMatches { get; } = [];
    }
}
