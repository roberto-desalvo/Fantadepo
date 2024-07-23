using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace RDS.Fantadepo.MAUI.ViewModels
{
    public partial class TurnListItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private ObservableCollection<MatchListItemViewModel> _matches = []; 
    }
}