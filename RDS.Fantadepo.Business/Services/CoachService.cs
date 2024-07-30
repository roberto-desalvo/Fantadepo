using AutoMapper;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;
using RDS.Fantadepo.WebApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDS.Fantadepo.WebApi.Business.Models.DTO;

namespace RDS.Fantadepo.WebApi.Business.Services
{
    public class CoachService(FantadepoContext context, IMapper mapper) : BaseService(context, mapper), ICoachService
    {
        public Task<int> CreateCoach(CoachDto coach)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCoach(int id)
        {
            throw new NotImplementedException();
        }

        public CoachDto? GetCoach(int id)
        {
            return _mapper.Map<CoachDto>(_context.Coaches.Find(id));
        }

        public IEnumerable<CoachDto> GetCoaches()
        {
            return _context.Coaches.Select(_mapper.Map<CoachDto>);
        }

        public Task<bool> UpdateCoach(int id, CoachDto coach)
        {
            throw new NotImplementedException();
        }

        Task<CoachDto?> ICoachService.GetCoach(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<CoachDto>> ICoachService.GetCoaches()
        {
            throw new NotImplementedException();
        }
    }
}
