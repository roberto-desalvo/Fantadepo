using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.DataAccess.Entities
{
    public class Turn
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly Date { get; set; }

        public int SeasonId { get; set; }
        public Season Season { get; set; } = new();

        public ICollection<Match> Matches { get; set; } = [];
        public ICollection<PlayerPerformance> PlayerPerformances { get; set; } = [];
    }

    public static class TurnModelCreator
    {
        public static void Configure(ModelBuilder mb)
        {
            mb.Entity<Turn>()
                .HasMany(t => t.Matches)
                .WithOne(m => m.Turn)
                .HasForeignKey(m => m.TurnId);

            mb.Entity<Turn>()
                .HasMany(t => t.PlayerPerformances)
                .WithOne(pp => pp.Turn)
                .HasForeignKey(pp => pp.TurnId);
        }
    }
}
