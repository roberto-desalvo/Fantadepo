using RDS.Fantadepo.Shared.Models;
using RDS.Fantadepo.Shared.SearchCriteria;

namespace RDS.Fantadepo.WebApi.Business.Services.Abstractions
{
    public interface ICoachService
    {
        Task<Coach?> GetCoach(int id, string? include = null);
        Task<IEnumerable<Coach>> GetCoaches(CoachSearchCriteria filter);
        Task<bool> UpdateCoach(int id, Coach coach);
        Task<int> CreateCoach(Coach coach);
        Task<bool> DeleteCoach(int id);
    }
}
