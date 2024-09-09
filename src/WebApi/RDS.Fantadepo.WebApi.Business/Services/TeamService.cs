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

        public async Task<IEnumerable<Team>> GetTeams(TeamSearchCriteria searchCriteria)
        {
            var query = _context.Teams.AsQueryable();

            if(searchCriteria.SeasonId.HasValue)
            {
                query = query.Where(x => x.SeasonId == searchCriteria.SeasonId);
            }

            if(searchCriteria.CoachId.HasValue)
            {
                query = query.Where(x => x.CoachId == searchCriteria.CoachId);
            }

            if(!string.IsNullOrWhiteSpace(searchCriteria.NamePattern))
            {
                query = query.Where(x => x.Name.Contains(searchCriteria.NamePattern, StringComparison.CurrentCultureIgnoreCase));
            }

            if(!string.IsNullOrWhiteSpace(searchCriteria.Include))
            {
                if(searchCriteria.Include.Contains("coach", StringComparison.CurrentCultureIgnoreCase))
                {
                    query = query.Include(x => x.Coach);
                }

                if(searchCriteria.Include.Contains("season", StringComparison.CurrentCultureIgnoreCase))
                {
                    query = query.Include(x => x.Season);
                }

                if(searchCriteria.Include.Contains("homematches", StringComparison.CurrentCultureIgnoreCase))
                {
                    query = query.Include(x => x.HomeMatches);
                }

                if(searchCriteria.Include.Contains("awaymatches", StringComparison.CurrentCultureIgnoreCase))
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
