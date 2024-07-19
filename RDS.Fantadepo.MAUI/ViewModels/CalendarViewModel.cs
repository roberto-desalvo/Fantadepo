using CommunityToolkit.Mvvm.ComponentModel;
using RDS.Fantadepo.Business.Models;

namespace RDS.Fantadepo.MAUI.ViewModels
{
    public partial class CalendarViewModel : ObservableObject
    {
        [ObservableProperty]
        private Season season = new();

        public void OpenTurn(Turn turn)
        {
            throw new NotImplementedException();
        }
    }
}
