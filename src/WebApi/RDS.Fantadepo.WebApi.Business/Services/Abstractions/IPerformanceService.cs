
namespace RDS.Fantadepo.WebApi.Business.Services.Abstractions
{
    public interface IPerformanceService
    {
        Task<bool> CalculatePerformanceSum(int performanceId);
    }
}