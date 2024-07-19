using RDS.Fantadepo.MAUI.Pages;
using RDS.Fantadepo.MAUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.MAUI.Extensions
{
    public static class UIServiceCollectionExtensions
    {
        public static IServiceCollection AddUIServices(this IServiceCollection services)
        {
            services.AddSingleton<MainPage>();
            services.AddSingleton<MainViewModel>();

            services.AddTransient<CalendarPage>();
            services.AddTransient<CalendarViewModel>();

            services.AddTransient<TeamListPage>();
            services.AddTransient<TeamListViewModel>();

            services.AddTransient<TeamPage>();
            services.AddTransient<TeamViewModel>();

            services.AddTransient<PlayerListPage>();
            services.AddTransient<PlayerListViewModel>();

            services.AddTransient<PlayerPage>();
            services.AddTransient<PlayerViewModel>();

            return services;
        }
    }
}
