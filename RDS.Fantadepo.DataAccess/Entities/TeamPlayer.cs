using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.DataAccess.Entities
{
    public class TeamPlayer
    {
        public int Id { get; set; }
        public bool IsFielded { get; set; }
        public int BenchPosition { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; } = new();

        public int PlayerId { get; set; }
        public Player Player { get; set; } = new();

        public Acquisition Acquisition { get; set; } = new();
        public Cession? Cession { get; set; }

        public ICollection<FieldedTeamPlayer> FieldedPlayers { get; set;} = [];

    }

    public static class TeamPlayerModelCreator
    {
        public static void Configure(ModelBuilder mb)
        {
            mb.Entity<TeamPlayer>()
                .HasMany(tp => tp.FieldedPlayers)
                .WithOne(ft => ft.TeamPlayer)
                .HasForeignKey(ft => ft.TeamPlayerId)
                .OnDelete(DeleteBehavior.NoAction);

            mb.Entity<TeamPlayer>()
                .HasOne(tp => tp.Acquisition)
                .WithOne(a => a.TeamPlayer)
                .HasForeignKey<Acquisition>(a => a.TeamPlayerId)
                .IsRequired();

            mb.Entity<TeamPlayer>()
                .HasOne(tp => tp.Cession)
                .WithOne(c => c.TeamPlayer)
                .HasForeignKey<Cession>(c => c.TeamPlayerId)
                .IsRequired(false);
        }
    }
}
