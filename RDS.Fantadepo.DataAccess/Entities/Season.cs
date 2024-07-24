using Microsoft.EntityFrameworkCore;
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

        public ICollection<Turn> Turns { get; set; } = [];
        public ICollection<TeamSeason> TeamSeasons { get; set; } = [];
    }

    public static class SeasonModelCreator
    {
        public static void Configure(ModelBuilder mb)
        {
            mb.Entity<Season>()
                .HasMany(s => s.Turns)
                .WithOne(t => t.Season)
                .HasForeignKey(s => s.SeasonId);

            mb.Entity<Season>()
                .HasMany(s => s.TeamSeasons)
                .WithOne(ts => ts.Season)
                .HasForeignKey(ts => ts.SeasonId);
        }
    }
}
