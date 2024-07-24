using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int CoachId { get; set; }
        public Coach Coach { get; set; } = new();      
        
        public ICollection<TeamSeason> TeamSeasons { get; set; } = [];
    }
}
