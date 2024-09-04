using RDS.Fantadepo.Models.Models;
using RDS.Fantadepo.WebApi.Business.Services.Filters;

namespace RDS.Fantadepo.WebApi.Business.Services.Abstractions
{
    public interface ITeamService
    {
        Task<int> CreateTeam(Team team);
        Task<bool> DeleteTeam(int id);
        Task<Team?> GetTeam(int id);
        Task<Team?> GetTeamWithCoach(int id);
        Task<IEnumerable<Team>> GetTeams(TeamFilter filter);
        Task<bool> UpdateTeam(int id, Team team);
    }
}
