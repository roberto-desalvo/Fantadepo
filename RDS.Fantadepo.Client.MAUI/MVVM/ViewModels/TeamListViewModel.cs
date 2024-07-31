using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RDA.Fantadepo.Client.MAUI.MVVM.Views;
using RDA.Fantadepo.Client.MAUI.Utilities;
using RDS.Fantadepo.Client.Business.Services.Abstractions;
using RDS.Fantadepo.Models.Models;
using System.Collections.ObjectModel;

namespace RDA.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    public partial class TeamListViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<TeamListItemViewModel> teams = [];

        private readonly ITeamsService _teamService;

        public TeamListViewModel(ITeamsService teamService)
        {
            _teamService = teamService ?? throw new ArgumentNullException(nameof(teamService));
            Task.Factory.StartNew(async () => { await LoadData(); });
        }

        private async Task LoadData()
        {
            var teams = await _teamService.GetTeams(AppBusinessContext.CurrentSeason.Id, true);

            foreach (var t in teams.Select(t => new TeamListItemViewModel(t)))
            {
                Teams.Add(t);
            }
        }

        [RelayCommand]
        public void AddTeam()
        {
            UIHelper.SafeCall(async () =>
            {
                await Task.CompletedTask;

                var data = new Dictionary<string, object> { { QueryAttributes.ISREADONLY, false } };
                await Shell.Current.GoToAsync(nameof(TeamDetailPage), data);

                // TODO aggiungere il nuovo team alla lista solo se l'utente salva
            });
        }

        public void OnModifyTeamName(Team team)
        {
            UIHelper.SafeCall(async () =>
            {
                await Task.CompletedTask;

                var data = new Dictionary<string, object> { 
                    { QueryAttributes.ISREADONLY, false },
                    { QueryAttributes.TEAMID, team.Id }
                };
                await Shell.Current.GoToAsync(nameof(TeamDetailPage), data);

                // TODO modificare il team solo se l'utente salva
            });
        }

    }
}

