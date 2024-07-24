using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RDS.Fantadepo.DataAccess;
using RDS.Fantadepo.MAUI.Extensions;
using RDS.Fantadepo.MAUI.Utils;
using RDS.Fantadepo.Business.Utilities;
using RDS.Fantadepo.Business.Utilities.Extensions;

namespace RDS.Fantadepo.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddUIServices();
            builder.Services.AddBusinessServices();
            builder.Services.AddAutoMapper(x => x.AddProfile<BusinessMapperProfile>());

            builder.Services.AddDbContext<FantadepoContext>(opt =>
             {
                 opt.UseSqlServer(AzureHelper.GetEntraIdConnectionString());
             });
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }


    }
}
