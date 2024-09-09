using CommunityToolkit.Mvvm.ComponentModel;
using RDS.Fantadepo.Shared.Models;

namespace RDS.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    public partial class CoachListItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private Coach? model;

        public int Id { get => Model?.Id ?? 0; }

        [ObservableProperty]
        private string coachFirstName = string.Empty;

        [ObservableProperty]
        private string coachLastName = string.Empty;

        public string Name => $"{CoachFirstName} {CoachLastName}";

        public CoachListItemViewModel(Coach? coach)
        {
            this.Model = coach;
            this.CoachFirstName = coach?.FirstName ?? string.Empty;
            this.CoachLastName = coach?.LastName ?? string.Empty;
        }
    }
}