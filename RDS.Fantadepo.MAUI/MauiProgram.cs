using Microsoft.Extensions.Logging;
using RDS.Fantadepo.MAUI.Extensions;
using RDS.Fantadepo.MAUI.Pages;
using RDS.Fantadepo.MAUI.ViewModels;

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
