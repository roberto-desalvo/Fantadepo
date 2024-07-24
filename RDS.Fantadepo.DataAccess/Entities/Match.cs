using Microsoft.EntityFrameworkCore;
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

        public int HomeTeamId { get; set; }
        public TeamSeason HomeTeam { get; set; } = new();
        public decimal? HomeTeamScore { get; set; }

        public int AwayTeamId { get; set; }
        public TeamSeason AwayTeam { get; set; } = new();
        public decimal? AwayTeamScore { get; set; }

        public int TurnId { get; set; }
        public Turn Turn { get; set; } = new();

        public ICollection<FieldedTeamPlayer> FieldedTeamPlayers { get; set; } = [];
    }

    public static class MatchModelCreator
    {
        public static void Configure(ModelBuilder mb)
        {
            mb.Entity<Match>()
                .HasMany(m => m.FieldedTeamPlayers)
                .WithOne(ftp => ftp.Match)
                .HasForeignKey(ftp => ftp.MatchId);
        }
    }
}
