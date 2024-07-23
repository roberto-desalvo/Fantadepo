using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Models
{
    public class TeamSeasonPlayer
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int SeasonPlayerId { get; set; }
        public int Price { get; set; }
        public DateOnly AcquisitionDay { get; set; }
        public DateOnly? SaleDate { get; set; }
        public bool IsActive { get; set; }
    }
}
