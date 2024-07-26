using Microsoft.EntityFrameworkCore;
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
        public Coach? Coach { get; set; } 

        public int SeasonId { get; set; }
        public Season? Season { get; set; } 

        public ICollection<Match> HomeMatches { get; set; } = [];
        public ICollection<Match> AwayMatches { get; set; } = [];
        public ICollection<TeamPlayer> TeamPlayers {  get; set; } = [];
        
    }

    public static class TeamModelCreator
    {
        public static void Configure(ModelBuilder mb)
        {
            mb.Entity<Team>()
                .HasMany(ts => ts.HomeMatches)
                .WithOne(hm => hm.HomeTeam)
                .HasForeignKey(hm => hm.HomeTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            mb.Entity<Team>()
                .HasMany(ts => ts.AwayMatches)
                .WithOne(am => am.AwayTeam)
                .HasForeignKey(am => am.AwayTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            mb.Entity<Team>()
                .HasMany(ts => ts.TeamPlayers)
                .WithOne(tp => tp.Team)
                .HasForeignKey(tp => tp.TeamId);
        }
    }
}
