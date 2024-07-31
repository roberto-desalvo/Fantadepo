using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.DataAccess.Entities
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

        public PlayerAcquisition PlayerAcquisition { get; set; } = new();
        public PlayerRelease? PlayerRelease { get; set; }

        public ICollection<FieldedTeamPlayer> FieldedPlayers { get; set;} = [];

    }

    public static class TeamPlayerModelCreator
    {
        public static void Configure(ModelBuilder mb)
        {
            mb.Entity<TeamPlayer>()
                .HasMany(tp => tp.FieldedPlayers)
                .WithOne(ft => ft.TeamPlayer)
                .HasForeignKey(ft => ft.TeamPlayerId);

            mb.Entity<TeamPlayer>()
                .HasOne(tp => tp.PlayerAcquisition)
                .WithOne(a => a.TeamPlayer)
                .HasForeignKey<PlayerAcquisition>(a => a.TeamPlayerId)
                .IsRequired();

            mb.Entity<TeamPlayer>()
                .HasOne(tp => tp.PlayerRelease)
                .WithOne(c => c.TeamPlayer)
                .HasForeignKey<PlayerRelease>(c => c.TeamPlayerId)
                .IsRequired(false);
        }
    }
}
