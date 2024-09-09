using RDS.Fantadepo.Shared.Models;

namespace RDS.Fantadepo.Client.Business.Services.Abstractions
{
    public interface ITeamService
    {
        Task<Team?> GetTeam(int id, bool includeCoach = false);
        Task<IEnumerable<Team>> GetTeams(int? seasonId = 0, bool includeCoach = false);
        Task<int> Save(Team team);
    }
}
