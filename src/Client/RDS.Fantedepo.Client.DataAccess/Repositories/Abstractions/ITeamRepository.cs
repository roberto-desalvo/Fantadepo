using RDS.Fantadepo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantedepo.Client.DataAccess.Repositories.Abstractions
{
    public interface ITeamRepository : ICrudRepository<Team>
    {
        Task<Team?> GetTeam(int id, bool withCoach, bool withSeason, bool withMatches);
        Task<IEnumerable<Team>> GetTeams(int? seasonId, bool withCoach, bool withSeason, bool withMatches);
    }
}
