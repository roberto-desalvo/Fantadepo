using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.DataAccess.Entities
{
    public class Season
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public ICollection<Turn> Turns { get; set; } = [];
        public ICollection<Team> Teams { get; set; } = [];
    }

    public static class SeasonModelConfigurator
    {
        public static void Configure(ModelBuilder mb)
        {
            mb.Entity<Season>()
                .HasMany(s => s.Turns)
                .WithOne(t => t.Season)
                .HasForeignKey(s => s.SeasonId);

            mb.Entity<Season>()
                .HasMany(s => s.Teams)
                .WithOne(ts => ts.Season)
                .HasForeignKey(ts => ts.SeasonId);
        }
    }
}
