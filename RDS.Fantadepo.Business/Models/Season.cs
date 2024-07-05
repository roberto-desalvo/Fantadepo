using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Models
{
    public class Season
    {
        public IList<Team> Teams { get; set; }
        public IList<Turn> Turns { get; set; }
    }
}
