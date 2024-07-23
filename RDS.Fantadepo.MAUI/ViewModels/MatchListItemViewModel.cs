using CommunityToolkit.Mvvm.ComponentModel;

namespace RDS.Fantadepo.MAUI.ViewModels
{
    public partial class MatchListItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private TeamDetailViewModel _homeTeam = new();

        [ObservableProperty]
        private TeamDetailViewModel _awayTeam = new();
    }
}