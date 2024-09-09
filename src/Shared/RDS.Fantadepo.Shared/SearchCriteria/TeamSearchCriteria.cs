using RDS.Fantadepo.Shared.Helpers;
using RDS.Fantadepo.Shared.SearchCriteria.Abstractions;

namespace RDS.Fantadepo.Shared.Models.SearchCriteria
{
    public class TeamSearchCriteria : ISearchCriteria
    {
        public int? SeasonId { get; set; }
        public int? CoachId { get; set; }
        public string? NamePattern { get; set; }
        public string? Include { get; set; }

        public Dictionary<string, string> GetParameters()
        {
            return Helper.ToStringDictionary(true, [
                    (QueryParamName.SeasonId, SeasonId),
                    (QueryParamName.CoachId, CoachId),
                    (QueryParamName.NamePattern, NamePattern),
                    (QueryParamName.Include, Include)
                ]);
        }

        public class QueryParamName
        {
            public const string SeasonId = "SeasonId";
            public const string CoachId = "CoachId";
            public const string NamePattern = "NamePattern";
            public const string Include = "Include";
            public const string IncludeCoach = "Coach";
            public const string IncludeSeason = "Season";
            public const string IncludeHomeMatches = "HomeMatches";
            public const string IncludeAwayMatches = "AwayMatches";
        }
    }
}
