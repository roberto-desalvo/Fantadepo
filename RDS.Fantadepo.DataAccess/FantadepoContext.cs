using Microsoft.EntityFrameworkCore;
using RDS.Fantadepo.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.DataAccess
{
    public class FantadepoContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<SeasonPlayer> SeasonPlayers { get; set; }
        public DbSet<TeamSeasonPlayer> TeamSeasonPlayers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Turn> Turns { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<PlayerPerformance> PlayerPerformances { get; set; }

        public FantadepoContext(DbContextOptions<FantadepoContext> opt) : base(opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Player>()
                .HasMany(x => x.SeasonPlayers)
                .WithOne(x => x.Player)
                .HasForeignKey(x => x.PlayerId);

            mb.Entity<Coach>()
                .HasMany(x => x.Teams)
                .WithOne(x => x.Coach)
                .HasForeignKey(x => x.CoachId);

            mb.Entity<Season>()
                .HasMany(x => x.SeasonPlayers)
                .WithOne(x => x.Season)
                .HasForeignKey(x => x.SeasonId);

            mb.Entity<Season>()
                .HasMany(x => x.Teams)
                .WithOne(x => x.Season)
                .HasForeignKey(x => x.SeasonId);

            mb.Entity<Season>()
                .HasMany(x => x.Turns)
                .WithOne(x => x.Season)
                .HasForeignKey(x => x.SeasonId);

            mb.Entity<Turn>()
                .HasMany(x => x.Matches)
                .WithOne(x => x.Turn)
                .HasForeignKey(x => x.TurnId);

            mb.Entity<Turn>()
                .HasMany(x => x.PlayerPerformances)
                .WithOne(x => x.Turn)
                .HasForeignKey(x => x.TurnId);

            mb.Entity<Team>()
                .HasMany(x => x.TeamSeasonPlayers)
                .WithOne(x => x.Team)
                .HasForeignKey(x => x.TeamId);

            mb.Entity<Team>()
                .HasMany(x => x.HomeMatches)
                .WithOne(x => x.HomeTeam)
                .HasForeignKey(x => x.HomeTeamId);

            mb.Entity<Team>()
                .HasMany(x => x.AwayMatches)
                .WithOne(x => x.AwayTeam)
                .HasForeignKey(x => x.AwayTeamId);

            mb.Entity<SeasonPlayer>()
                .HasMany(x => x.TeamSeasonPlayers)
                .WithOne(x => x.SeasonPlayer)
                .HasForeignKey(x => x.SeasonPlayerId);

            mb.Entity<SeasonPlayer>()
                .HasMany(x => x.Performances)
                .WithOne(x => x.SeasonPlayer)
                .HasForeignKey(x => x.SeasonPlayerId);

            base.OnModelCreating(mb);
        }
    }
}
