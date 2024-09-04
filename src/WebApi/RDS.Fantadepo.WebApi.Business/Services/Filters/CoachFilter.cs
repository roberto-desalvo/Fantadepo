using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Services.Filters
{
    public class CoachFilter
    {
        public int? TeamId { get; set; }
        public string? FirstNamePattern { get; set; }
        public string? LastNamePattern { get; set; }
        public string? Include { get; set; }
    }
}
