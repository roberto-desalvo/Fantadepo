using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RDA.Fantadepo.Client.MAUI.Utilities;
using RDS.Fantadepo.Client.Business.Services.Abstractions;
using RDS.Fantadepo.Models.Models;
using System.Collections.ObjectModel;

namespace RDA.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    public partial class TeamDetailViewModel : ObservableObject, IQueryAttributable
    {
        private Team? model;
        public int Id { get => model?.Id ?? 0; private set => model = new Team { Id = value }; }

        [ObservableProperty]
        private bool isReadonly = true;

        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private ObservableCollection<CoachListItemViewModel> coaches = [];

        [ObservableProperty]
        private CoachListItemViewModel selectedCoach = new(null);


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
            if(this.Id == 0)
            {
                model = new Team
                {
                    Name = Name,
                    Season = AppBusinessContext.CurrentSeason
                };                
            }
            else
            {
                model!.Name = this.Name;
            }

            if (SelectedCoach.Id != 0)
            {
                var newCoach = await _coachesService.GetCoach(SelectedCoach.Id);

                if(newCoach != null)
                {
                    model.Coach = newCoach;
                }
            }

            var id = await _teamsService.Save(model);

            await Shell.Current.GoToAsync($"..?result={id}");
        }

        private async void LoadData()
        {
            var team = await _teamsService.GetTeam(this.Id, true);
            var coaches = await _coachesService.GetCoaches();
            FillModel(team, coaches);
        }

        private void FillModel(Team? team, IEnumerable<Coach> coaches)
        {
            model = team ?? new();
            Name = team?.Name ?? string.Empty;
            Coaches = new(coaches.Select(c => new CoachListItemViewModel(c)));

            if (coaches.Any(x => x.Id == team?.Coach?.Id))
            {
                SelectedCoach = new(team?.Coach);
            }
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            this.Id = query.TryGetValue(QueryAttributes.TEAMID, out object? idValue) ? (int)idValue  : 0;
            IsReadonly = query.TryGetValue(QueryAttributes.ISREADONLY, out object? readonlyValue) ? (bool)readonlyValue : true;
        }
    }
}
