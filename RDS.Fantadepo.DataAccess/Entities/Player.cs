using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.DataAccess.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;

        public ICollection<TeamPlayer> TeamPlayers { get; set; } = [];
        public ICollection<PlayerPerformance> PlayerPerformances { get; set; } = [];
    }

    public static class PlayerModelCreator
    {
        public static void Configure(ModelBuilder mb)
        {
            mb.Entity<Player>()
                .HasMany(p => p.TeamPlayers)
                .WithOne(tp => tp.Player)
                .HasForeignKey(tp => tp.PlayerId);

            mb.Entity<Player>()
                .HasMany(p => p.PlayerPerformances)
                .WithOne(pp => pp.Player)
                .HasForeignKey(pp => pp.PlayerId);
        }
    }
}
