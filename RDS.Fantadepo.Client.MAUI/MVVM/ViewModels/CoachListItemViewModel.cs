using CommunityToolkit.Mvvm.ComponentModel;
using RDS.Fantadepo.Models.Models;

namespace RDA.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    public partial class CoachListItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private string coachFirstName = string.Empty;

        [ObservableProperty]
        private string coachLastName = string.Empty;

        public CoachListItemViewModel(Coach? coach)
        {
            if(coach is null)
            {
                return;
            }
            this.CoachFirstName = coach.FirstName;
            this.CoachLastName = coach.LastName;
        }
    }
}