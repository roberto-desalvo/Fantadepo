using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;
using RDS.Fantadepo.WebApi.DataAccess;
using RDS.Fantadepo.Models.Models;
using Entities = RDS.Fantadepo.WebApi.DataAccess.Entities;
using RDS.Fantadepo.WebApi.Business.Services.Filters;

namespace RDS.Fantadepo.WebApi.Business.Services
{
    public class TeamService : BaseService, ITeamService
    {
        public TeamService(FantadepoContext context, IMapper mapper) : base(context, mapper)
        {
            
        }

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

        public async Task<IEnumerable<Team>> GetTeams(TeamFilter filter)
        {
            var query = _context.Teams.AsQueryable();

            if(filter.SeasonId.HasValue)
            {
                query = query.Where(x => x.SeasonId == filter.SeasonId);
            }

            if(filter.CoachId.HasValue)
            {
                query = query.Where(x => x.CoachId == filter.CoachId);
            }

            if(!string.IsNullOrWhiteSpace(filter.NamePattern))
            {
                query = query.Where(x => x.Name.Contains(filter.NamePattern));
            }

            if(!string.IsNullOrWhiteSpace(filter.Include))
            {
                if(filter.Include.ToLower() == "coach")
                {
                    query = query.Include(x => x.Coach);
                }

                if(filter.Include.ToLower() == "season")
                {
                    query = query.Include(x => x.Season);
                }

                if(filter.Include.ToLower() == "homeMatches")
                {
                    query = query.Include(x => x.HomeMatches);
                }

                if(filter.Include.ToLower() == "awayMatches")
                {
                    query = query.Include(x => x.AwayMatches);
                }
            }

            var results = await query.ToListAsync();
            return _mapper.Map<IEnumerable<Team>>(results);
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
