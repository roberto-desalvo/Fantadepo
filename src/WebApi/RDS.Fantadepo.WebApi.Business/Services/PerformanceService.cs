using AutoMapper;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;
using RDS.Fantadepo.WebApi.DataAccess;
using RDS.Fantadepo.Models.Models;
using RDS.Fantadepo.WebApi.Business.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RDS.Fantadepo.WebApi.Business.Options;

namespace RDS.Fantadepo.WebApi.Business.Services
{
    public class PerformanceService : BaseService, IPerformanceService
    {
        private readonly ScoreOptions _scoreOptions;
        public PerformanceService(FantadepoContext context, IMapper mapper, IOptions<ScoreOptions> scoreOptions) : base(context, mapper)
        {
            _scoreOptions = scoreOptions.Value;
        }

        public async Task<bool> CalculatePerformanceSum(int performanceId)
        {
            var performance = await _context.PlayerPerformances.FirstOrDefaultAsync(p => p.Id == performanceId);

            if(performance == null)
            {
                return false;
            }

            performance.Sum = PerformanceHelper.GetPerformanceSum(performance, _scoreOptions);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
