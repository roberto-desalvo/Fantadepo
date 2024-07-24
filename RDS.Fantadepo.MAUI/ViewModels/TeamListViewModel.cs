using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RDS.Fantadepo.Business.Models;
using RDS.Fantadepo.MAUI.Models;
using System.Collections.ObjectModel;

namespace RDS.Fantadepo.MAUI.ViewModels
{
    public partial class TeamListViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<TeamListItemViewModel> teams = [];

        [RelayCommand]
        public void AddTeam()
        {
            UIHelper.SafeCall(async () =>
            {
                //var team = new TeamDetailViewModel { Name = "Insert team name" };
                //var data = new Dictionary<string, object> { { nameof(Team), team } };
                //await Shell.Current.GoToAsync(nameof(TeamDetailPage), data);
                //Teams.Add(team);
            });
        }

        public void OnModifyTeamName(Team team)
        {
            UIHelper.SafeCall(async () =>
            {
                //var data = new Dictionary<string, object> { { nameof(Player), team } };
                //await Shell.Current.GoToAsync(nameof(TeamDetailPage), data);
            });
        }

    }
}

