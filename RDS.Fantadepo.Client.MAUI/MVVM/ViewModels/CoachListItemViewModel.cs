using CommunityToolkit.Mvvm.ComponentModel;
using RDS.Fantadepo.Models.Models;

namespace RDS.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    public partial class CoachListItemViewModel : ObservableObject
    {
        private Coach? model;
        public int Id { get => model?.Id ?? 0; }

        [ObservableProperty]
        private string coachFirstName = string.Empty;

        [ObservableProperty]
        private string coachLastName = string.Empty;

        public CoachListItemViewModel(Coach? coach)
        {
            this.model = coach;
            this.CoachFirstName = coach?.FirstName ?? string.Empty;
            this.CoachLastName = coach?.LastName ?? string.Empty;
        }
    }
}