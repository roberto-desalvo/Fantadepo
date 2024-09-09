using RDS.Fantadepo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.MAUI.Messages
{
    public class TeamAddedMessage
    {
        public int Id { get; set; }
        public Team Team {  get; set; } 
    }
}
