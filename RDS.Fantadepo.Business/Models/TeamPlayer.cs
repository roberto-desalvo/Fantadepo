using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Models
{
    public class TeamPlayer
    {
        public int Id { get; set; }
        public bool IsFielded { get; set; }
        public int BenchPosition { get; set; }

        public int TeamSeasonId { get; set; }
        public TeamSeason TeamSeason { get; set; } = new();

        public int PlayerId { get; set; }
        public Player Player { get; set; } = new();

        public PlayerAcquisition Acquisition { get; set; } = new();
        public PlayerRelease? Cession { get; set; }

        public ICollection<FieldedTeamPlayer> FieldedPlayers { get; set;} = [];

    }
}
