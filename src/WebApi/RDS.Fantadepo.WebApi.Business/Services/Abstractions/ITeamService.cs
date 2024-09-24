using RDS.Fantadepo.Shared.Models;
using RDS.Fantadepo.Shared.Models.SearchCriteria;

namespace RDS.Fantadepo.WebApi.Business.Services.Abstractions
{
    public interface ITeamService
    {
        Task<int> CreateTeam(Team team);
        Task<bool> DeleteTeam(int id);
        Task<Team?> GetTeam(int id, string? include = null);
        Task<IEnumerable<Team>> GetTeams(TeamSearchCriteria searchCriteria);
        Task ImportTeamsWithCoachesFromRosterFile(string path);
        Task<bool> UpdateTeam(int id, Team team);
    }
}
