using Microsoft.Extensions.DependencyInjection;
using RDS.Fantadepo.Business.Services;
using RDS.Fantadepo.Business.Services.Abstractions;
using RDS.Fantadepo.Business.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Extensions
{
    public static class BusinessServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddAutoMapper(x => x.AddProfile<BusinessMapperProfile>());
            return services;
        }
    }
}
