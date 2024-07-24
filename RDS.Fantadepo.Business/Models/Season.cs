using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Models
{
    public class Season
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Turn> Turns { get; set; } = [];
        public ICollection<TeamSeason> TeamSeasons { get; set; } = [];
    }
}
