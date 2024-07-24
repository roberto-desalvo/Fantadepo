using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RDS.Fantadepo.Business.Models;
using RDS.Fantadepo.Business.Services.Abstractions;
using RDS.Fantadepo.MAUI.Utilities;
using System.Collections.ObjectModel;

namespace RDS.Fantadepo.MAUI.ViewModels
{
    public partial class TeamListViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<TeamListItemViewModel> teams = [];

        private readonly ITeamService _teamService;

        public TeamListViewModel(ITeamService teamService)
        {
            _teamService = teamService ?? throw new ArgumentNullException(nameof(teamService));
            LoadData();
        }

        private void LoadData()
        {
            Teams = new();
            var teams = _teamService.GetTeamsWithCoaches();
            foreach (var team in teams)
            {
                var model = new TeamListItemViewModel(team);
                Teams.Add(model);
            }
        }

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

