using CommunityToolkit.Mvvm.ComponentModel;
using RDS.Fantadepo.Client.Business.Services.Abstractions;
using RDS.Fantadepo.Models.Models;

namespace RDS.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    public partial class TeamListItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private Team? model;
        public int Id { get => Model?.Id ?? 0; private set => Model = new Team { Id = value }; }

        private readonly ITeamService _teamsService;

        public TeamListItemViewModel(ITeamService teamService)
        {
            _teamsService = teamService ?? throw new ArgumentNullException(nameof(teamService));
            Task.Factory.StartNew(async () => await LoadAsync(null));
        }

        public TeamListItemViewModel(Team? team)
        {
            Task.Factory.StartNew(async () => await LoadAsync(team));
        }

        public async Task LoadAsync(Team? team)
        {            
            Model = (team is null && Id != 0) ? await _teamsService.GetTeam(Id) : team;
        }
    }
}
