using RDS.Fantadepo.MAUI.MVVM.Views;
using RDS.Fantadepo.Models.Models;

namespace RDS.Fantadepo.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();            

            StaticData.CurrentSeason = new Season { Name = "2024/2025"};
            this.Title = $"Fantadepo {StaticData.CurrentSeason.Name}";
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(CalendarPage), typeof(CalendarPage));
            Routing.RegisterRoute(nameof(TeamListPage), typeof(TeamListPage));
            Routing.RegisterRoute(nameof(PlayerListPage), typeof(PlayerListPage));
            Routing.RegisterRoute(nameof(PlayerDetailPage), typeof(PlayerDetailPage));
            Routing.RegisterRoute(nameof(TeamDetailPage), typeof(TeamDetailPage));
        }
    }
}
