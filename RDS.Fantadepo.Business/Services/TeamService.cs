using AutoMapper;
using RDS.Fantadepo.Business.Models;
using RDS.Fantadepo.Business.Services.Abstractions;
using RDS.Fantadepo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Services
{
    public class TeamService(FantadepoContext context, IMapper mapper) : BaseService(context, mapper), ITeamService
    {
        public Team? GetTeam(int id)
        {
            var team = _context.Teams.Find(id);
            return _mapper.Map<Team>(team);
        }

        public IEnumerable<Team> GetTeams(Func<Team, bool>? predicate = null)
        {
            Func<Team, bool> all = x => true;
            return _mapper.Map<IEnumerable<Team>>(_context.Teams).Where(predicate ?? all);
        }
    }
}
