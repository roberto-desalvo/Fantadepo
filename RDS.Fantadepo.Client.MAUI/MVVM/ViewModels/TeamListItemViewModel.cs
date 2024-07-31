using CommunityToolkit.Mvvm.ComponentModel;
using RDS.Fantadepo.Models.Models;

namespace RDA.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    public partial class TeamListItemViewModel : ObservableObject
    {
        private Team? model;
        public int Id { get => model?.Id ?? 0; private set => model = new Team { Id = value }; }

        [ObservableProperty]
        private string coachFirstName = string.Empty;

        [ObservableProperty]
        private string coachLastName = string.Empty;

        [ObservableProperty]
        private string teamName = string.Empty;

        public TeamListItemViewModel(Team? team)
        {
            model = team;
            this.TeamName = team?.Name ?? string.Empty;
            this.CoachFirstName = team?.Coach?.FirstName ?? string.Empty;
            this.CoachLastName = team?.Coach?.LastName ?? string.Empty;
        }
    }
}
