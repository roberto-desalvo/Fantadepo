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
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamSeason> TeamSeasons { get; set; }
        public DbSet<TeamPlayer> TeamPlayers { get; set; }
        public DbSet<FieldedTeamPlayer> FieldedTeamPlayers { get; set; }
        public DbSet<Turn> Turns { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<PlayerPerformance> PlayerPerformances { get; set; }
        public DbSet<Acquisition> Acquisitions { get; set; }
        public DbSet<Cession> Cessions { get; set; }

        public FantadepoContext(DbContextOptions<FantadepoContext> opt) : base(opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            CoachModelCreator.Configure(mb);
            MatchModelCreator.Configure(mb);
            PlayerModelCreator.Configure(mb);
            SeasonModelCreator.Configure(mb);
            TeamModelCreator.Configure(mb);
            TeamPlayerModelCreator.Configure(mb);
            TeamSeasonModelCreator.Configure(mb);
            TurnModelCreator.Configure(mb);

            base.OnModelCreating(mb);
        }
    }
}
