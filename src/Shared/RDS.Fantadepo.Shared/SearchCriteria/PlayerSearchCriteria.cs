using RDS.Fantadepo.Shared.Helpers;
using RDS.Fantadepo.Shared.SearchCriteria.Abstractions;

namespace RDS.Fantadepo.Shared.Models.SearchCriteria
{
    public class PlayerSearchCriteria : ISearchCriteria
    {
        public string? FirstnamePattern { get; set; }
        public string? LastnamePattern { get; set; }
        public string? NicknamePattern { get; set; }
        public string? Include { get; set; }

        public Dictionary<string, string> GetParameters()
        {
            return Helper.ToStringDictionary(true, [
                (QueryParamName.FirstNamePattern, FirstnamePattern),
                (QueryParamName.LastNamePattern, LastnamePattern),
                (QueryParamName.NicknamePattern, NicknamePattern),
                (QueryParamName.Include, Include)
                ]);
        }

        public class QueryParamName
        {
            public const string FirstNamePattern = "FirstNamePattern";
            public const string LastNamePattern = "LastNamePattern";
            public const string NicknamePattern = "NicknamePattern";
            public const string Include = "Include";
        }

        public class IncludeOptions
        {
            public const string IncludeTeamPlayers = "TeamPlayers";
            public const string IncludePerformances = "Performances";
        }
    }
}
