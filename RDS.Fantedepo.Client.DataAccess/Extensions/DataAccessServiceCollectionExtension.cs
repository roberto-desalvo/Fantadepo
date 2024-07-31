using Microsoft.Extensions.DependencyInjection;
using RDS.Fantedepo.Client.DataAccess.Repositories;
using RDS.Fantedepo.Client.DataAccess.Repositories.Abstractions;
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
            services.AddScoped<ICoachesRepository, CoachesRepository>();
            services.AddScoped<ITeamsRepository, TeamsRepository>();

            return services;
        }
    }
}
