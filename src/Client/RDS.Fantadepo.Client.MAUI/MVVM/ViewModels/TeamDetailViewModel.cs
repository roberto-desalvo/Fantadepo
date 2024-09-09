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
        private Team? model;

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

        private async Task LoadData(int? id)
        {
            Model = (id != null) 
                ? await _teamsService.GetTeam(id.Value) ?? new()
                : new();

            Coaches = new((await _coachesService.GetCoaches()).Select(c => new CoachListItemViewModel(c)));
            Model.Season = Model.Season ?? AppBusinessContext.CurrentSeason;
            SelectedCoach = Coaches.FirstOrDefault(c => c.Model?.Id == Model.CoachId);
            Model.Coach = SelectedCoach?.Model;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            query.TryGetValue(QueryAttributes.TEAMID, out object? id);

            IsReadonly = query.TryGetValue(QueryAttributes.ISREADONLY, out object? isReadonly) ? (bool)isReadonly : true;
            Task.Factory.StartNew(async () =>
            {
                await LoadData((int?)id);
            });
        }
    }
}
