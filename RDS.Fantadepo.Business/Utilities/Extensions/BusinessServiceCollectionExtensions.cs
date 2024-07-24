using Microsoft.Extensions.DependencyInjection;
using RDS.Fantadepo.Business.Services;
using RDS.Fantadepo.Business.Services.Abstractions;

namespace RDS.Fantadepo.Business.Utilities.Extensions
{
    public static class BusinessServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IMatchService, MatchService>();
            services.AddTransient<ITurnService, TurnService>();
            services.AddTransient<IPerformanceService, PerformanceService>();
            services.AddTransient<ITeamService, TeamService>();
            
            return services;
        }
    }
}
