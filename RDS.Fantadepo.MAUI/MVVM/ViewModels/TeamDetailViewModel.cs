using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RDS.Fantadepo.MAUI.Utilities;
using System.Collections.ObjectModel;

namespace RDS.Fantadepo.MAUI.MVVM.ViewModels
{
    public partial class TeamDetailViewModel : ObservableObject, IQueryAttributable
    {
        private int id;

        [ObservableProperty]
        private bool isReadonly = true;

        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private ObservableCollection<CoachListItemViewModel> coaches = [];

        [ObservableProperty]
        private CoachListItemViewModel selectedCoach = new(null);


        //private readonly ITeamService _teamService;
        //private readonly ICoachService _coachService;

        //public TeamDetailViewModel(ITeamService teamService, ICoachService coachService)
        //{
        //    _teamService = teamService ?? throw new ArgumentNullException(nameof(teamService));
        //    _coachService = coachService ?? throw new ArgumentNullException(nameof(coachService));
        //    LoadData();
        //}

        [RelayCommand]
        public void Save()
        {
            // TODO
        }

        //private void LoadData()
        //{            

        //    var team = _teamService.GetTeamWithCoach(id);
        //    var coaches = _coachService.GetCoaches();
        //    FillModel(team, coaches);
        //}

        //private void FillModel(Team? team, IEnumerable<Coach> coaches)
        //{
        //    Name = team?.Name ?? string.Empty;
        //    Coaches = new(coaches.Select(c => new CoachListItemViewModel(c)));

        //    if(coaches.Any(x => x.Id == team?.Coach?.Id)) 
        //    {
        //        SelectedCoach = new(team?.Coach);
        //    }
        //}

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            id = query.TryGetValue(QueryAttributes.TEAMID, out object? idValue) ? (int)idValue  : 0;
            IsReadonly = query.TryGetValue(QueryAttributes.ISREADONLY, out object? readonlyValue) ? (bool)readonlyValue : true;
        }
    }
}
