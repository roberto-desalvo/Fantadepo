using RDS.Fantadepo.Models.Models;
using RDS.Fantedepo.Client.DataAccess.Repositories.Abstractions;
using RDS.Fantedepo.Client.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantedepo.Client.DataAccess.Repositories
{
    public class TeamRepository : BaseRepository, ITeamRepository
    {
        public TeamRepository(Context context) : base(context)
        {
        }

        public Task<int> CreateTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTeam(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Team?> GetTeam(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Team>> GetTeams(Func<Team, bool>? predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Team>> GetTeamsWithCoaches(Func<Team, bool>? predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<Team?> GetTeamWithCoach(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTeam(int id, Team team)
        {
            throw new NotImplementedException();
        }
    }
}
