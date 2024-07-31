using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RDS.Fantadepo.MAUI.Utilities;
using RDS.Fantadepo.Models.Models;
using System.Collections.ObjectModel;

namespace RDS.Fantadepo.MAUI.MVVM.ViewModels
{
    public partial class TeamListViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<TeamListItemViewModel> teams = [];

        //private readonly ITeamService _teamService;

        //public TeamListViewModel(ITeamService teamService)
        //{
        //    _teamService = teamService ?? throw new ArgumentNullException(nameof(teamService));
        //    LoadData();
        //}

        //private void LoadData()
        //{
        //    var teams = _teamService.GetTeamsWithCoaches().Select(t => new TeamListItemViewModel(t));

        //    foreach(var t in teams)
        //    {
        //        Teams.Add(t);
        //    }
        //}

        [RelayCommand]
        public void AddTeam()
        {
            UIHelper.SafeCall(async () =>
            {
                await Task.CompletedTask;

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
                await Task.CompletedTask;

                //var data = new Dictionary<string, object> { { nameof(Player), team } };
                //await Shell.Current.GoToAsync(nameof(TeamDetailPage), data);
            });
        }

    }
}

