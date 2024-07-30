using AutoMapper;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;
using RDS.Fantadepo.WebApi.DataAccess;
using RDS.Fantadepo.Models.Models;

namespace RDS.Fantadepo.WebApi.Business.Services
{
    public class CoachService(FantadepoContext context, IMapper mapper) : BaseService(context, mapper), ICoachService
    {
        public Task<int> CreateCoach(Coach coach)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCoach(int id)
        {
            throw new NotImplementedException();
        }

        public Coach? GetCoach(int id)
        {
            return _mapper.Map<Coach>(_context.Coaches.Find(id));
        }

        public IEnumerable<Coach> GetCoaches()
        {
            return _context.Coaches.Select(_mapper.Map<Coach>);
        }

        public Task<bool> UpdateCoach(int id, Coach coach)
        {
            throw new NotImplementedException();
        }

        Task<Coach?> ICoachService.GetCoach(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Coach>> ICoachService.GetCoaches()
        {
            throw new NotImplementedException();
        }
    }
}
