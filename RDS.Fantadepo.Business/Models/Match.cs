using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }

        public int HomeTeamSeasonId { get; set; }
        public TeamSeason HomeTeamSeason { get; set; } = new();
        public decimal? HomeTeamScore { get; set; }

        public int AwayTeamSeasonId { get; set; }
        public TeamSeason AwayTeamSeason { get; set; } = new();
        public decimal? AwayTeamScore { get; set; }

        public int TurnId { get; set; }
        public Turn Turn { get; set; } = new();

        public ICollection<FieldedTeamPlayer> FieldedTeamPlayers { get; set; } = [];
    }

}
