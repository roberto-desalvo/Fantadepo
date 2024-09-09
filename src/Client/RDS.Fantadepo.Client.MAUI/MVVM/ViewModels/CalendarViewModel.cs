using CommunityToolkit.Mvvm.ComponentModel;
using RDS.Fantadepo.Shared.Models;
using System.Collections.ObjectModel;

namespace RDS.Fantadepo.Client.MAUI.MVVM.ViewModels
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
