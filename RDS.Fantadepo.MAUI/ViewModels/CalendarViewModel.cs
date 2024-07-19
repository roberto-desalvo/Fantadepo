using CommunityToolkit.Mvvm.ComponentModel;
using RDS.Fantadepo.Business.Models;
using System.Collections.ObjectModel;

namespace RDS.Fantadepo.MAUI.ViewModels
{
    public partial class CalendarViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<TurnListItemViewModel> turns = new();

        public void OpenTurn(Turn turn)
        {
            throw new NotImplementedException();
        }
    }
}
