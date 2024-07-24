using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.DataAccess.Entities
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

    public static class TeamSeasonModelCreator
    {
        public static void Configure(ModelBuilder mb)
        {
            mb.Entity<TeamSeason>()
                .HasMany(ts => ts.TeamPlayers)
                .WithOne(tp => tp.TeamSeason)
                .HasForeignKey(tp => tp.TeamSeasonId);

            mb.Entity<TeamSeason>()
                .HasMany(ts => ts.HomeMatches)
                .WithOne(hm => hm.HomeTeam)
                .HasForeignKey(hm => hm.HomeTeamId);

            mb.Entity<TeamSeason>()
                .HasMany(ts => ts.AwayMatches)
                .WithOne(am => am.AwayTeam)
                .HasForeignKey(am => am.AwayTeamId);
        }
    }
}
