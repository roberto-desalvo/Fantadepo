using RDS.Fantadepo.Client.Business.Services.Abstractions;
using RDS.Fantadepo.Models.Models;
using RDS.Fantedepo.Client.DataAccess.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Client.Business.Services
{
    public class TeamsService : ITeamsService
    {
        private readonly ITeamsRepository _repo;

        public TeamsService(ITeamsRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<Team?> GetTeam(int id, bool includeCoach = false)
        {
            return await _repo.GetTeam(id, includeCoach);
        }

        public async Task<IEnumerable<Team>> GetTeams(int? seasonId = 0, bool includeCoach = false)
        {
            return await _repo.GetTeams(seasonId, includeCoach);
        }

        public async Task<int> Save(Team team)
        {
            return await ((team.Id == 0) ? _repo.Create(team) : _repo.Update(team.Id, team));
        }
    }
}
