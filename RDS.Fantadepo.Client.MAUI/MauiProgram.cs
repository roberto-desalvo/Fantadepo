using Microsoft.Extensions.Logging;
using RDA.Fantadepo.Client.MAUI.Extensions;
using RDS.Fantadepo.Client.Business.Extensions;

namespace RDA.Fantadepo.Client.MAUI
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
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }


    }
}
