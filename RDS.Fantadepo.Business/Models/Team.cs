using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Models
{
    public class Team
    {
        public string Name { get; set; }
        public IList<Player> Players { get; set; }
    }
}
