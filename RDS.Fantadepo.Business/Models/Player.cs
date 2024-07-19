using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Models
{
    public class Player : ICloneable
    {
        public int Id { get; set; }

        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;
        public PlayerRole FirstRole { get; set; }
        public PlayerRole SecondaryRole { get; set; }

        public object Clone()
        {
            return new Player
            {
                Id = Id,
                Firstname = Firstname,
                Lastname = Lastname,
                FirstRole = FirstRole,
                SecondaryRole = SecondaryRole                
            };
        }

        public enum PlayerRole
        {
            [EnumMember(Value ="Goalkeeper")]
            GoalKeeper = 1,

            [EnumMember(Value = "Pivot")]
            Pivot = 2,

            [EnumMember(Value = "Defender")]
            Defender = 3,
            
            [EnumMember(Value = "Winger")] 
            Winger = 4
        }
    }
}
