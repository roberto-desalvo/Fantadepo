using RDS.Fantadepo.WebApi.DataAccess;

namespace RDS.Fantadepo.MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
