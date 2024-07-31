using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using RDS.Fantadepo.Client.MAUI.Utilities;
using RDS.Fantadepo.Client.Business.Services.Abstractions;
using RDS.Fantadepo.MAUI.Messages;
using RDS.Fantadepo.Models.Models;
using System.Collections.ObjectModel;

namespace RDS.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    [QueryProperty(nameof(Id), QueryAttributes.TEAMID)]
    [QueryProperty(nameof(IsReadonly), QueryAttributes.ISREADONLY)]
    public partial class TeamDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private Team? model;
        
        public int Id { get => Model?.Id ?? 0; private set => Model = new Team { Id = value }; }

        [ObservableProperty]
        private bool isReadonly = true;

        [ObservableProperty]
        private ObservableCollection<CoachListItemViewModel> coaches = [];


        private readonly ITeamsService _teamsService;
        private readonly ICoachesService _coachesService;

        public TeamDetailViewModel(ITeamsService teamService, ICoachesService coachService)
        {
            _teamsService = teamService ?? throw new ArgumentNullException(nameof(teamService));
            _coachesService = coachService ?? throw new ArgumentNullException(nameof(coachService));
            LoadData();
        }

        [RelayCommand]
        public async Task Save()
        {
            var id = await _teamsService.Save(Model!);
            WeakReferenceMessenger.Default.Send(new TeamAddedMessage { Id = id });
        }

        private async void LoadData()
        {
            Model = Id == 0 ? new() : await _teamsService.GetTeam(this.Id, true);
            if(Model!.Season == null)
            {
                Model.Season = AppBusinessContext.CurrentSeason;
            }
            Coaches = new ((await _coachesService.GetCoaches()).Select(c => new CoachListItemViewModel(c)));
        }
    }
}
