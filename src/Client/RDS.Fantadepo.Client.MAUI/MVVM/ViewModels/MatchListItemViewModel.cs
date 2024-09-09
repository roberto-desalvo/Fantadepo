using CommunityToolkit.Mvvm.ComponentModel;
using RDS.Fantadepo.Shared.Models;

namespace RDS.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    public partial class MatchListItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private Match? model;

        public MatchListItemViewModel(Match? match)
        {
            Model = match;
        }
    }
}