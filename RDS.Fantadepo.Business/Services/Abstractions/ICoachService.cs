using RDS.Fantadepo.WebApi.Business.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Services.Abstractions
{
    public interface ICoachService
    {
        Task<CoachDto?> GetCoach(int id);
        Task<IEnumerable<CoachDto>> GetCoaches();
        Task<bool> UpdateCoach(int id, CoachDto coach);
        Task<int> CreateCoach(CoachDto coach);
        Task<bool> DeleteCoach(int id);
    }
}
