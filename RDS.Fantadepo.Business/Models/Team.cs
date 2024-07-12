using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Models
{
    public class Team : ICloneable
    {
        public string Name { get; set; } = string.Empty;
        public IList<Player> Players { get; set; } = new List<Player>();

        public object Clone()
        {
            return new Team
            {
                Name = Name,
                Players = Players.Select(x => x.Clone() as Player).ToList()
            };
        }
    }
}
