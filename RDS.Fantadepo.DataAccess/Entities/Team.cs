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
        public Coach Coach { get; set; } = new();      
        
        public ICollection<TeamSeason> TeamSeasons { get; set; } = [];
    }

    public static class TeamModelCreator
    {
        public static void Configure(ModelBuilder mb)
        {
            mb.Entity<Team>()
                .HasMany(t => t.TeamSeasons)
                .WithOne(ts => ts.Team)
                .HasForeignKey(ts => ts.TeamId);
        }
    }
}
