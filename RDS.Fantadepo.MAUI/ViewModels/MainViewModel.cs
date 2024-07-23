using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RDS.Fantadepo.DataAccess;
using RDS.Fantadepo.MAUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.MAUI.ViewModels
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
