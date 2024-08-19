using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;
using RDS.Fantadepo.WebApi.DataAccess;
using RDS.Fantadepo.Models.Models;
using Entities = RDS.Fantadepo.WebApi.DataAccess.Entities;

namespace RDS.Fantadepo.WebApi.Business.Services
{
    public class TeamService(FantadepoContext context, IMapper mapper) : BaseService(context, mapper), ITeamService
    {
        private Func<Team, bool> noFilter = x => true;

        public async Task<int> CreateTeam(Team team)
        {
            var entity = _mapper.Map<Entities.Team>(team);
            _context.Teams.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> DeleteTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return false;
            }

            var entity = _mapper.Map<Entities.Team>(team);
            _context.Teams.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Team?> GetTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            return _mapper.Map<Team>(team);
        }

        public async Task<IEnumerable<Team>> GetTeams(Func<Team, bool>? predicate = null)
        {
            var t = Task.Factory.StartNew(() =>
            {
                var entities = _context.Teams;
                var teams = _mapper.Map<IEnumerable<Team>>(entities);
                return teams.Where(predicate ?? noFilter);
            });

            return await t;
        }

        public async Task<IEnumerable<Team>> GetTeamsWithCoaches(Func<Team, bool>? predicate = null)
        {
            var t = Task.Factory.StartNew(() => 
            {
                var entities = _context.Teams.Include(x => x.Coach);
                var teams = _mapper.Map<IEnumerable<Team>>(entities);
                return teams.Where(predicate ?? noFilter);
            });

            return await t;
        }

        public async Task<Team?> GetTeamWithCoach(int id)
        {
            return _mapper.Map<Team>(await _context.Teams.Include(x => x.Coach).FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<bool> UpdateTeam(int id, Team team)
        {
            if (id != team.Id)
            {
                return false;
            }

            if (!TeamExists(id))
            {
                return false;
            }

            var entity = _mapper.Map<Entities.Team>(team);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}
