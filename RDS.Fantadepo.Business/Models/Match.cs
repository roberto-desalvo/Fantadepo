using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Models
{
    public class Match : ICloneable
    {
        public Team Team1 { get; set; } = new Team();
        public Team Team2 { get; set; } = new Team();

        public object Clone()
        {
            return new Match
            {
                Team1 = (Team1.Clone() as Team)!,
                Team2 = (Team2.Clone() as Team)!
            };
        }
    }
}
