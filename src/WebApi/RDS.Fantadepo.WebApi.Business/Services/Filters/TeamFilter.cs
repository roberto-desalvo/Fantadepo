using RDS.Fantadepo.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Services.Filters
{
    public class TeamFilter
    {
        public int? SeasonId { get; set; }
        public int? CoachId { get; set; }
        public string? NamePattern { get; set; } 
        public string? Include { get; set; } 
    }
}
