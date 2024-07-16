using RDS.Fantadepo.MAUI.Pages;

namespace RDS.Fantadepo.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CalendarPage), typeof(CalendarPage));
            Routing.RegisterRoute(nameof(TeamsPage), typeof(TeamsPage));
            Routing.RegisterRoute(nameof(PlayersPage), typeof(PlayersPage));
        }
    }
}
