using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace RDA.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    public partial class TurnListItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private ObservableCollection<MatchListItemViewModel> _matches = []; 
    }
}