using Newtonsoft.Json;
using RDS.Fantadepo.Models.Models;
using RDS.Fantedepo.Client.DataAccess.Helpers;
using RDS.Fantedepo.Client.DataAccess.Repositories.Abstractions;
using RDS.Fantedepo.Client.DataAccess.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDS.Fantedepo.Client.DataAccess.Repositories
{
    public class TeamsRepository : CrudRepository<Team>, ITeamsRepository
    {
        public TeamsRepository(Context context) : base(context)
        {
            customPath = ApiHelper.GetCustomPath();
        }

        public Task<Team?> GetTeam(int id, bool withCoach)
        {
            var parameters = new TeamsQueryParameters { IncludeCoach = withCoach };
            return base.Get(id, parameters);
        }

        public Task<IEnumerable<Team>> GetTeams(int? seasonId, bool withCoaches)
        {
            var parameters = new TeamsQueryParameters { IncludeCoach = withCoaches, SeasonId = seasonId };
            return base.Get(parameters);
        }
    }
}
