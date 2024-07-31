using RDA.Fantadepo.Client.MAUI.MVVM.Views;
using RDS.Fantadepo.Models.Models;

namespace RDA.Fantadepo.Client.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();            

            AppBusinessContext.CurrentSeason = new Season { Name = "2024/2025"};
            this.Title = $"Fantadepo {AppBusinessContext.CurrentSeason.Name}";
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
