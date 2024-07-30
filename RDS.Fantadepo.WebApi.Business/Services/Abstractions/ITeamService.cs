using RDS.Fantadepo.Models.Models;

namespace RDS.Fantadepo.WebApi.Business.Services.Abstractions
{
    public interface ITeamService
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
