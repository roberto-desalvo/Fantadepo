using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantedepo.Client.DataAccess.Helpers
{
    public class TeamsQueryParameters : IQueryParameters
    {
        public int? SeasonId { get; set; }
        public bool? IncludeCoach { get; set; }

        public Dictionary<string, string> GetParameters()
        {
            return ApiHelper.ToStringDictionary([("seasonId", SeasonId), ("includeCoach", IncludeCoach)]);
        }
    }
}
