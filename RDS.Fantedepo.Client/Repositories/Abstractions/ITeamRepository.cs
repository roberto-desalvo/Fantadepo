using RDS.Fantadepo.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantedepo.Client.DataAccess.Repositories.Abstractions
{
    public interface ITeamRepository
    {
        Task<int> CreateTeam(Team team);
        Task<bool> DeleteTeam(int id);
        Task<Team?> GetTeam(int id);
        Task<Team?> GetTeamWithCoach(int id);
        Task<IEnumerable<Team>> GetTeams(Func<Team, bool>? predicate = null);
        Task<IEnumerable<Team>> GetTeamsWithCoaches(Func<Team, bool>? predicate = null);
        Task<bool> UpdateTeam(int id, Team team);
    }
}
