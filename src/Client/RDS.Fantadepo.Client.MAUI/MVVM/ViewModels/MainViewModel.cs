using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RDS.Fantadepo.Client.MAUI.MVVM.Views;

namespace RDS.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {       
        [RelayCommand]
        public async Task OpenTeamsPage()
        {
            await Shell.Current.GoToAsync(nameof(TeamListPage));
        }

        [RelayCommand]
        public async Task OpenCalendarPage()
        {
            await Shell.Current.GoToAsync(nameof(CalendarPage));
        }

        [RelayCommand]
        public async Task OpenPlayersPage()
        {
            await Shell.Current.GoToAsync(nameof(PlayerListPage));
        }
    }
}
