using CommunityToolkit.Mvvm.ComponentModel;
using RDS.Fantadepo.Models.Models;

namespace RDA.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    public partial class MatchListItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _homeTeamName = string.Empty;

        [ObservableProperty]
        private string _awayTeamName = string.Empty;

        public MatchListItemViewModel(Match? match)
        {
            _homeTeamName = match?.HomeTeam?.Name ?? string.Empty;
            _awayTeamName = match?.AwayTeam?.Name ?? string.Empty;
        }
    }
}