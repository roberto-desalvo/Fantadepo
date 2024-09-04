using RDS.Fantadepo.Models.Models;
using RDS.Fantadepo.WebApi.Business.Services.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Services.Abstractions
{
    public interface ICoachService
    {
        Task<Coach?> GetCoach(int id);
        Task<IEnumerable<Coach>> GetCoaches(CoachFilter filter);
        Task<bool> UpdateCoach(int id, Coach coach);
        Task<int> CreateCoach(Coach coach);
        Task<bool> DeleteCoach(int id);
    }
}
