using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Models
{
    public class Player : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public object Clone()
        {
            return new Player
            {
                Id = Id,
                Name = Name
            };
        }

        public enum PlayerRole
        {
            GoalKeeper,
            Pivot,
            Defender,
            Winger
        }
    }
}
