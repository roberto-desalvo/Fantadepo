using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RDS.Fantadepo.Client.MAUI.MVVM.Views;
using RDS.Fantadepo.Client.MAUI.Utilities;
using RDS.Fantadepo.Models.Models;

namespace RDS.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    public partial class TeamListItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private Team? model;
        public int Id { get => Model?.Id ?? 0; private set => Model = new Team { Id = value }; }

        public TeamListItemViewModel(Team? team)
        {
            Model = team;
        }

        [RelayCommand]
        public void ModifyTeam()
        {
            UIHelper.SafeCall(async () =>
            {
                var data = new Dictionary<string, object>
                {
                    { QueryAttributes.ISREADONLY, false },
                    { QueryAttributes.TEAMID, Model?.Id ?? 0 }
                };
                await Shell.Current.GoToAsync(nameof(TeamDetailPage), data);
            });
        }

        [RelayCommand]
        public void DisplayTeamDetail()
        {
            UIHelper.SafeCall(async () =>
            {
                var data = new Dictionary<string, object>
                {
                    { QueryAttributes.ISREADONLY, true },
                    { QueryAttributes.TEAMID, Model?.Id ?? 0 }
                };
                await Shell.Current.GoToAsync(nameof(TeamDetailPage), data);
            });
        }
    }
}
