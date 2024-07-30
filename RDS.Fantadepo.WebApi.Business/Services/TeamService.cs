using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;
using RDS.Fantadepo.WebApi.DataAccess;
using RDS.Fantadepo.Models.Models;

namespace RDS.Fantadepo.WebApi.Business.Services
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

        public IEnumerable<Team> GetTeamsBySeason(int seasonId)
        {
            return _context.Teams
                .Where(x => x.SeasonId == seasonId)
                .Select(_mapper.Map<Team>);
        }

        public IEnumerable<Team> GetTeamsWithCoaches()
        {
            return _mapper.Map<IEnumerable<Team>>(_context.Teams.Include(x => x.Coach));
        }

        public Team? GetTeamWithCoach(int id)
        {
            return _mapper.Map<Team>(_context.Teams.Include(x => x.Coach).FirstOrDefault(x => x.Id == id));
        }
    }
}
