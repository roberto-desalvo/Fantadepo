﻿using AutoMapper;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;
using RDS.Fantadepo.WebApi.DataAccess;
using RDS.Fantadepo.Shared.Models;
using Entities = RDS.Fantadepo.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using RDS.Fantadepo.Shared.SearchCriteria;

namespace RDS.Fantadepo.WebApi.Business.Services
{
    public class CoachService(FantadepoContext context, IMapper mapper) : BaseService(context, mapper), ICoachService
    {
        public async Task<int> CreateCoach(Coach coach)
        {
            var entity = _mapper.Map<Entities.Coach>(coach);
            _context.Coaches.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> DeleteCoach(int id)
        {
            var coach = await _context.Coaches.FindAsync(id);
            if (coach == null)
            {
                return false;
            }

            var entity = _mapper.Map<Entities.Coach>(coach);
            _context.Coaches.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Coach?> GetCoach(int id, string? include = null)
        {
            Entities.Coach? coach;

            if(string.IsNullOrWhiteSpace(include))
            {
                coach = await _context.Coaches.FindAsync(id);
            }
            else
            {
                var query = _context.Coaches.AsQueryable();
                if (include.Contains(CoachSearchCriteria.IncludeOptions.IncludeTeam,
                    StringComparison.CurrentCultureIgnoreCase))
                {
                    query = query.Include(x => x.Team);
                }
                coach = await query.FirstOrDefaultAsync();
            }

            return _mapper.Map<Coach>(coach);
        }

        public async Task<IEnumerable<Coach>> GetCoaches(CoachSearchCriteria searchCriteria)
        {
            var query = _context.Coaches.AsQueryable();

            if(searchCriteria.TeamId.HasValue)
            {
                query = query.Where(x => x.Team == _context.Teams.Where(t => t.Id == searchCriteria.TeamId));
            }

            if(!string.IsNullOrEmpty(searchCriteria.FirstNamePattern))
            {
                query = query.Where(x => x.FirstName.Contains(searchCriteria.FirstNamePattern, StringComparison.CurrentCultureIgnoreCase));
            }

            if(!string.IsNullOrEmpty(searchCriteria.LastNamePattern))
            {
                query = query.Where(x => x.LastName.Contains(searchCriteria.LastNamePattern, StringComparison.CurrentCultureIgnoreCase));
            }

            if(!string.IsNullOrEmpty(searchCriteria.Include))
            {
                if(searchCriteria.Include.Contains(CoachSearchCriteria.IncludeOptions.IncludeTeam, 
                    StringComparison.CurrentCultureIgnoreCase))
                {
                    query = query.Include(x => x.Team);
                }
            }

            var results = await query.ToListAsync();
            return _mapper.Map<IEnumerable<Coach>>(results);
        }

        public async Task<bool> UpdateCoach(int id, Coach coach)
        {
            if (id != coach.Id)
            {
                return false;
            }

            if(!CoachExists(id))
            {
                return false;
            }

            var entity = _mapper.Map<Entities.Coach>(coach);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        private bool CoachExists(int id)
        {
            return _context.Coaches.Any(e => e.Id == id);
        }
    }
}
