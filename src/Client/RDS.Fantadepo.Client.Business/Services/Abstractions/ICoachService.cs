using RDS.Fantadepo.Shared.Models;

namespace RDS.Fantadepo.Client.Business.Services.Abstractions
{
    public interface ICoachService
    {
        Task<Coach?> GetCoach(int id);
        Task<IEnumerable<Coach>> GetCoaches();
        Task<int> Save(Coach coach);
    }
}
