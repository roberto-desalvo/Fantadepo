using RDS.Fantadepo.Models.Models;

namespace RDS.Fantadepo.WebApi.Business.Services.Abstractions
{
    public interface ITeamService
    {
        Team? GetTeam(int id);
        IEnumerable<Team> GetTeams(Func<Team, bool>? predicate = null);
        IEnumerable<Team> GetTeamsWithCoaches();
        Team? GetTeamWithCoach(int id);
    }
}
