using Microsoft.Extensions.Logging;
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

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddTransient<CalendarPage>();
            builder.Services.AddTransient<CalendarViewModel>();

            builder.Services.AddTransient<TeamListPage>();
            builder.Services.AddTransient<TeamListViewModel>();

            builder.Services.AddTransient<PlayerListPage>();
            builder.Services.AddTransient<PlayerListViewModel>();

            builder.Services.AddTransient<PlayerPage>();
            builder.Services.AddTransient<PlayerViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
