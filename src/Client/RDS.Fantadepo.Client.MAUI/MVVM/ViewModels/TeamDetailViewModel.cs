using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using RDS.Fantadepo.Client.MAUI.Utilities;
using RDS.Fantadepo.Client.Business.Services.Abstractions;
using RDS.Fantadepo.MAUI.Messages;
using RDS.Fantadepo.Shared.Models;
using System.Collections.ObjectModel;

namespace RDS.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    public partial class TeamDetailViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private Team model = new();
        
        public int Id { get => Model?.Id ?? 0; private set => Model = new Team { Id = value }; }

        [ObservableProperty]
        private bool isReadonly = true;

        [ObservableProperty]
        private ObservableCollection<CoachListItemViewModel> coaches = [];

        [ObservableProperty]
        private CoachListItemViewModel? selectedCoach;


        private readonly ITeamService _teamsService;
        private readonly ICoachService _coachesService;

        public TeamDetailViewModel(ITeamService teamService, ICoachService coachService)
        {
            _teamsService = teamService ?? throw new ArgumentNullException(nameof(teamService));
            _coachesService = coachService ?? throw new ArgumentNullException(nameof(coachService));            
        }

        [RelayCommand]
        public async Task Save()
        {
            var id = await _teamsService.Save(Model!);
            WeakReferenceMessenger.Default.Send(new TeamAddedMessage { Id = id });
        }

        private async void LoadData()
        {
            Model = Id == 0 ? new() : await _teamsService.GetTeam(this.Id, true) ?? new();                           
            Coaches = new ((await _coachesService.GetCoaches()).Select(c => new CoachListItemViewModel(c)));

            if(Model != null)
            {
                Model.Season = Model.Season ?? AppBusinessContext.CurrentSeason;
                SelectedCoach = Coaches.FirstOrDefault(c => c.Id == Model.CoachId);
                Model.Coach = SelectedCoach?.Model;
            }            
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Id = query.ContainsKey(QueryAttributes.TEAMID) ? (int)query[QueryAttributes.TEAMID] : 0;
            IsReadonly = query.ContainsKey(QueryAttributes.ISREADONLY) ? (bool)query[QueryAttributes.ISREADONLY] : true;
            LoadData();
        }
    }
}
