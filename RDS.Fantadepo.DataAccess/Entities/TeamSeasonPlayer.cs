using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.DataAccess.Entities
{
    public class TeamSeasonPlayer
    {
        public int Id { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; } = new();

        public int SeasonPlayerId { get; set; }
        public SeasonPlayer SeasonPlayer { get; set; } = new();

        public int Price { get; set; }
        public DateOnly AcquisitionDay { get; set; }
        public DateOnly? SaleDate { get; set; } // if set, player is not in the team anymore
    }
}
