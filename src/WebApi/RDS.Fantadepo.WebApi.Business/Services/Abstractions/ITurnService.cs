using RDS.Fantadepo.Models.Models;

namespace RDS.Fantadepo.WebApi.Business.Services.Abstractions
{
    public interface ITurnService
    {
        public void CalculatePerformancesForTurn(Turn turn);
    }
}
