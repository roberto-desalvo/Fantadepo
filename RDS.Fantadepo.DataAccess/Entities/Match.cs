using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.DataAccess.Entities
{
    public class Match
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }

        public int HomeMatchTeamId { get; set; }
        public MatchTeam HomeMatchTeam { get; set; } = new();
        public decimal? HomeTeamScore { get; set; }

        public int AwayMatchTeamId { get; set; }
        public MatchTeam AwayMatchTeam { get; set; } = new();
        public decimal? AwayTeamScore { get; set; }

        public int TurnId { get; set; }
        public Turn Turn { get; set; } = new();
    }
}
