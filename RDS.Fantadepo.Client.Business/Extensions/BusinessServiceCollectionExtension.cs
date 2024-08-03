using Microsoft.Extensions.DependencyInjection;
using RDS.Fantadepo.Client.Business.Services.Abstractions;
using RDS.Fantadepo.Client.Business.Services;
using RDS.Fantedepo.Client.DataAccess.Extensions;

namespace RDS.Fantadepo.Client.Business.Extensions
{
    public static class BusinessServiceCollectionExtension
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddDataAccessServices();
            services.AddScoped<ICoachService, CoachService>();
            services.AddScoped<ITeamService, TeamService>();

            return services;
        }
    }
}
