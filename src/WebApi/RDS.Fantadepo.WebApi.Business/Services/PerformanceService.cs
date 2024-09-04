using AutoMapper;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;
using RDS.Fantadepo.WebApi.DataAccess;
using RDS.Fantadepo.Models.Models;
using RDS.Fantadepo.WebApi.Business.Utilities;
using Microsoft.EntityFrameworkCore;

namespace RDS.Fantadepo.WebApi.Business.Services
{
    public class PerformanceService : BaseService, IPerformanceService
    {
        public PerformanceService(FantadepoContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<bool> CalculatePerformanceSum(int performanceId)
        {
            var performance = await _context.PlayerPerformances.FirstOrDefaultAsync(p => p.Id == performanceId);

            if(performance == null)
            {
                return false;
            }

            performance.Sum = PerformanceHelper.GetPerformanceSum(performance);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
