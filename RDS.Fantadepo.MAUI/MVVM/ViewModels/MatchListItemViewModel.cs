using CommunityToolkit.Mvvm.ComponentModel;

namespace RDS.Fantadepo.MAUI.MVVM.ViewModels
{
    public partial class MatchListItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _homeTeamName = string.Empty;

        [ObservableProperty]
        private string _awayTeamName = string.Empty;
    }
}