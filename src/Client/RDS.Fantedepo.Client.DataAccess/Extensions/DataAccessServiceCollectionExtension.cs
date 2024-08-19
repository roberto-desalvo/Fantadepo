using Microsoft.Extensions.DependencyInjection;
using RDS.Fantedepo.Client.DataAccess.Repositories;
using RDS.Fantedepo.Client.DataAccess.Repositories.Abstractions;
using RDS.Fantedepo.Client.DataAccess.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantedepo.Client.DataAccess.Extensions
{
    public static class DataAccessServiceCollectionExtension
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped<ICoachRepository, CoachRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<ContextSettings>();
            services.AddScoped<Context>();

            return services;
        }
    }
}
