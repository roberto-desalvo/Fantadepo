using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Models
{
    public class Season
    {
        public string Name { get; set; } = string.Empty;
        public IList<Team> Teams { get; set; } = [];
        public IList<Turn> Turns { get; set; } = [];
    }
}
