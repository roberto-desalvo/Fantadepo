using RDS.Fantadepo.Shared.Helpers;
using RDS.Fantadepo.Shared.SearchCriteria.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Shared.SearchCriteria
{
    public class CoachSearchCriteria : ISearchCriteria
    {
        public int? TeamId { get; set; }
        public string? FirstNamePattern { get; set; }
        public string? LastNamePattern { get; set; }
        public string? Include { get; set; }

        public Dictionary<string, string> GetParameters()
        {
            return Helper.ToStringDictionary(true, [
                (QueryParamName.Include, TeamId),
                (QueryParamName.FirstNamePattern, FirstNamePattern),
                (QueryParamName.LastNamePattern, LastNamePattern),
                (QueryParamName.Include, Include)
                ]);
        }

        public class QueryParamName
        {
            public const string TeamId = "TeamId";
            public const string FirstNamePattern = "FirstNamePattern";
            public const string LastNamePattern = "LastNamePattern";
            public const string Include = "Include";            
        }

        public class IncludeOptions
        {
            public const string IncludeTeam = "Team";
        }
    }
}
