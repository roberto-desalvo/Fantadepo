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
    public class TeamRepository : CrudRepository<Team>, ITeamRepository
    {
        public TeamRepository(Context context) : base(context)
        {
        }

        public Task<Team?> GetTeam(int id, bool withCoach)
        {
            var parameters = new TeamQueryParameters { IncludeCoach = withCoach };
            return base.Get(id, parameters);
        }

        public Task<IEnumerable<Team>> GetTeams(int? seasonId, bool withCoaches)
        {
            var parameters = new TeamQueryParameters { IncludeCoach = withCoaches, SeasonId = seasonId };
            return base.Get(parameters);
        }
    }
}
