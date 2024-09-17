using Microsoft.Extensions.DependencyInjection;
using RDS.Fantadepo.WebApi.Business.Services;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;
using RDS.Fantadepo.WebApi.DataAccess.Utilities;
using RDS.Fantadepo.WebApi.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RDS.Fantadepo.WebApi.DataAccess.Options;
using RDS.Fantadepo.DataIngestion;

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
            services.AddTransient<ICoachService, CoachService>();

            services.AddDbContext<FantadepoContext>((serviceProvider,opt) =>
            {
                var kvOptions = serviceProvider.GetRequiredService<IOptions<KeyVaultOptions>>().Value;
                opt.UseSqlServer(AzureHelper.GetAdminConnectionString(kvOptions));
            });

            ImportSeedData();

            return services;
        }

        private static void ImportSeedData()
        {
            var path = "C:\\github\\Fantadepo\\resources\\seasons\\2023-24\\Rose iniziali.xlsx";

            var teams = FantadepoExcelFileReader.GetTeamsWithCoachesFromRosterFile(path);
            var players = FantadepoExcelFileReader.GetPlayersFromRosterFile(path);

            return;
        }
    }
}
