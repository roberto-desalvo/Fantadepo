using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Models
{
    public class Acquisition
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public int Price { get; set; }
        public int TeamPlayerId { get; set; }
        public TeamPlayer TeamPlayer { get; set; } = new();
    }
}
