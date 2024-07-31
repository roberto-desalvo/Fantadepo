using CommunityToolkit.Mvvm.ComponentModel;
using RDS.Fantadepo.Models.Models;

namespace RDA.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    public partial class TeamListItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private string coachFirstName = string.Empty;

        [ObservableProperty]
        private string coachLastName = string.Empty;

        [ObservableProperty]
        private string teamName = string.Empty;

        public TeamListItemViewModel(Team team)
        {
            this.TeamName = team.Name;
            this.CoachFirstName = team.Coach.FirstName;
            this.CoachLastName = team.Coach.LastName;
        }
    }
}
