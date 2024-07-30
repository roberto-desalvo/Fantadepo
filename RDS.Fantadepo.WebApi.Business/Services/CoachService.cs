using AutoMapper;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;
using RDS.Fantadepo.WebApi.DataAccess;
using RDS.Fantadepo.Models.Models;
using Entities = RDS.Fantadepo.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Coach?> GetCoach(int id)
        {
            return _mapper.Map<Coach>(await _context.Coaches.FindAsync(id));
        }

        public async Task<IEnumerable<Coach>> GetCoaches()
        {
            return _mapper.Map<IEnumerable<Coach>>(await _context.Coaches.FindAsync());
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
