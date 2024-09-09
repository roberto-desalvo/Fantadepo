using RDS.Fantadepo.Shared.Models;
using RDS.Fantadepo.Shared.Models.SearchCriteria;
using RDS.Fantedepo.Client.DataAccess.Repositories.Abstractions;
using RDS.Fantedepo.Client.DataAccess.Settings;
using System.Text;

namespace RDS.Fantedepo.Client.DataAccess.Repositories
{
    public class TeamRepository : CrudRepository<Team>, ITeamRepository
    {
        public TeamRepository(Context context) : base(context)
        {
        }

        public Task<Team?> GetTeam(int id, bool withCoach, bool withSeason, bool withMatches)
        {
            var include = GetIncludeString(withCoach, withSeason, withMatches);
            var parameters = new TeamSearchCriteria { Include = include };
            return base.Get(id, parameters);
        }        

        public Task<IEnumerable<Team>> GetTeams(int? seasonId, bool withCoach, bool withSeason, bool withMatches)
        {
            var include = GetIncludeString(withCoach, withSeason, withMatches);
            var parameters = new TeamSearchCriteria { Include = include, SeasonId = seasonId };
            return base.Get(parameters);
        }

        private static string GetIncludeString(bool withCoach, bool withSeason, bool withMatches)
        {
            var sb = new StringBuilder();
            if (withCoach)
            {
                sb.Append(TeamSearchCriteria.QueryParamName.IncludeCoach);
                sb.Append(';');
            }
            if (withSeason)
            {
                sb.Append(TeamSearchCriteria.QueryParamName.IncludeSeason);
                sb.Append(';');
            }
            if (withMatches)
            {
                sb.Append(TeamSearchCriteria.QueryParamName.IncludeHomeMatches);
                sb.Append(';');
                sb.Append(TeamSearchCriteria.QueryParamName.IncludeAwayMatches);
                sb.Append(';');
            }

            return sb.ToString();
        }
    }
}
