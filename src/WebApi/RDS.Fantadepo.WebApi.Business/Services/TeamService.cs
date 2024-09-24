using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;
using RDS.Fantadepo.WebApi.DataAccess;
using RDS.Fantadepo.Shared.Models;
using Entities = RDS.Fantadepo.WebApi.DataAccess.Entities;
using RDS.Fantadepo.Shared.Models.SearchCriteria;
using RDS.Fantadepo.DataIngestion;

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

        public async Task<Team?> GetTeam(int id, string? include = null)
        {
            Entities.Team? team;

            if (string.IsNullOrWhiteSpace(include))
            {
                team = await _context.Teams.FindAsync(id);
            }
            else
            {
                var query = _context.Teams.AsQueryable();
                query = IncludeRelatedEntities(include, query);
                team = await query.FirstOrDefaultAsync();
            }

            return _mapper.Map<Team>(team);
        }

        public async Task<IEnumerable<Team>> GetTeams(TeamSearchCriteria searchCriteria)
        {
            var query = _context.Teams.AsQueryable();

            if (searchCriteria.SeasonId.HasValue)
            {
                query = query.Where(x => x.SeasonId == searchCriteria.SeasonId);
            }

            if (searchCriteria.CoachId.HasValue)
            {
                query = query.Where(x => x.CoachId == searchCriteria.CoachId);
            }

            if (!string.IsNullOrWhiteSpace(searchCriteria.NamePattern))
            {
                query = query.Where(x => x.Name.Contains(searchCriteria.NamePattern, StringComparison.CurrentCultureIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(searchCriteria.Include))
            {
                query = IncludeRelatedEntities(searchCriteria.Include, query);
            }

            var results = await query.ToListAsync();
            return _mapper.Map<IEnumerable<Team>>(results);
        }

        private static IQueryable<Entities.Team> IncludeRelatedEntities(string include, IQueryable<Entities.Team> query)
        {
            if (string.IsNullOrWhiteSpace(include))
            {
                return query;
            }

            if (include.Contains(TeamSearchCriteria.QueryParamName.IncludeCoach,
                StringComparison.CurrentCultureIgnoreCase))
            {
                query = query.Include(x => x.Coach);
            }

            if (include.Contains(TeamSearchCriteria.QueryParamName.IncludeSeason, 
                StringComparison.CurrentCultureIgnoreCase))
            {
                query = query.Include(x => x.Season);
            }

            if (include.Contains(TeamSearchCriteria.QueryParamName.IncludeHomeMatches, 
                StringComparison.CurrentCultureIgnoreCase))
            {
                query = query.Include(x => x.HomeMatches);
            }

            if (include.Contains(TeamSearchCriteria.QueryParamName.IncludeAwayMatches, 
                StringComparison.CurrentCultureIgnoreCase))
            {
                query = query.Include(x => x.AwayMatches);
            }

            return query;
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

        public async Task ImportTeamsWithCoachesFromRosterFile(string path)
        {
            var teams = FantadepoExcelFileReader.GetTeamsWithCoachesFromRosterFile(path);

            foreach (var team in teams)
            {
                var entityExists = (await _context.Teams.FirstOrDefaultAsync(t => t.Name == team.Name)) is not null;

                if (!entityExists)
                {
                    var toInsert = _mapper.Map<Entities.Team>(team);
                    if (toInsert.Coach != null)
                    {
                        var coachEntity = await _context.Coaches.FirstOrDefaultAsync(c => c.FirstName == toInsert.Coach.FirstName && c.LastName == toInsert.Coach.LastName);

                        if (coachEntity != null)
                        {
                            toInsert.Coach = coachEntity;
                        }
                    }
                    await _context.Teams.AddAsync(toInsert);
                }
            }

            await _context.SaveChangesAsync();
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}
