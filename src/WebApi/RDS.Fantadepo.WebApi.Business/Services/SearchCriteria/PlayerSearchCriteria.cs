using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Services.SearchCriteria
{
    public class PlayerSearchCriteria
    {
        public string? FirstnamePattern { get; set; }
        public string? LastnamePattern { get; set; }
        public string? NicknamePattern { get; set; }
        public string? Include { get; set; }
    }
}
