using CommunityToolkit.Mvvm.ComponentModel;
using RDS.Fantadepo.Shared.Models;

namespace RDS.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    public partial class CoachListItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private Coach? model;

        public string Name => $"{Model?.FirstName} {Model?.LastName}";

        public CoachListItemViewModel(Coach? coach)
        {
            this.Model = coach;
        }
    }
}