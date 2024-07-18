using RDS.Fantadepo.MAUI.Pages;

namespace RDS.Fantadepo.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CalendarPage), typeof(CalendarPage));
            Routing.RegisterRoute(nameof(TeamListPage), typeof(TeamListPage));
            Routing.RegisterRoute(nameof(PlayerListPage), typeof(PlayerListPage));
            Routing.RegisterRoute(nameof(PlayerPage), typeof(PlayerPage));
        }
    }
}
