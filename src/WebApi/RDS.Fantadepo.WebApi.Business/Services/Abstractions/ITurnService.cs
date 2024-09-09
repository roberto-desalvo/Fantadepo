using RDS.Fantadepo.Shared.Models;

namespace RDS.Fantadepo.WebApi.Business.Services.Abstractions
{
    public interface ITurnService
    {
        public Task<bool> CalculateTurn(int turnId, IList<PlayerPerformance> performances);
    }
}
