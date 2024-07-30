using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RDS.Fantadepo.WebApi.DataAccess;
using RDS.Fantadepo.MAUI.Extensions;
using RDS.Fantadepo.Business.Utilities;
using RDS.Fantadepo.Business.Utilities.Extensions;
using RDS.Fantadepo.WebApi.DataAccess.Utilities;

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
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }


    }
}
