using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Models
{
    public class SeasonPlayer
    {
        public int Id { get; set; }        
        public int? FirstRole { get; set; }
        public int? SecondaryRole { get; set; }
        public int SeasonId { get; set; }
        public int PlayerId { get; set; }
    }
}
