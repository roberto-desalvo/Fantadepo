﻿using Microsoft.EntityFrameworkCore;
using RDS.Fantadepo.WebApi.DataAccess.Entities;
using RDS.Fantadepo.WebApi.DataAccess.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.DataAccess
{
    public class FantadepoContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamPlayer> TeamPlayers { get; set; }
        public DbSet<FieldedTeamPlayer> FieldedTeamPlayers { get; set; }
        public DbSet<Turn> Turns { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<PlayerPerformance> PlayerPerformances { get; set; }
        public DbSet<PlayerAcquisition> PlayerAcquisitions { get; set; }
        public DbSet<PlayerRelease> PlayerReleases { get; set; }

        public FantadepoContext()
        {
            
        }

        public FantadepoContext(DbContextOptions<FantadepoContext> opt) : base(opt)
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(AzureHelper.GetAdminConnectionString());
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder mb)
        {
            CoachModelCreator.Configure(mb);
            MatchModelCreator.Configure(mb);
            PlayerModelCreator.Configure(mb);
            SeasonModelCreator.Configure(mb);
            TeamModelCreator.Configure(mb);
            TeamPlayerModelCreator.Configure(mb);
            TurnModelCreator.Configure(mb);

            base.OnModelCreating(mb);
        }
    }
}
