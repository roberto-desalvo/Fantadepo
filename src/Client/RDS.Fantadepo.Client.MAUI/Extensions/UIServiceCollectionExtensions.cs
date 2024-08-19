using RDS.Fantadepo.Client.MAUI.MVVM.Views;
using RDS.Fantadepo.Client.MAUI.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Client.MAUI.Extensions
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

            services.AddTransient<TeamDetailPage>();
            services.AddTransient<TeamDetailViewModel>();

            services.AddTransient<PlayerListPage>();
            services.AddTransient<PlayerListViewModel>();

            services.AddTransient<PlayerDetailPage>();
            services.AddTransient<PlayerDetailViewModel>();

            return services;
        }
    }
}
