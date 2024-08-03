using RDS.Fantadepo.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Client.Business.Services.Abstractions
{
    public interface ITeamService
    {
        Task<Team?> GetTeam(int id, bool includeCoach = false);
        Task<IEnumerable<Team>> GetTeams(int? seasonId = 0, bool includeCoach = false);
        Task<int> Save(Team team);
    }
}
