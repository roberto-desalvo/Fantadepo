using Microsoft.Extensions.DependencyInjection;
using RDS.Fantadepo.WebApi.Business.Services;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;

namespace RDS.Fantadepo.WebApi.Business.Utilities.Extensions
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
