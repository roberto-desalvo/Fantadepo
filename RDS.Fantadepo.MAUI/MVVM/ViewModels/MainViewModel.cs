using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RDS.Fantadepo.WebApi.DataAccess;
using RDS.Fantadepo.MAUI.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.MAUI.MVVM.ViewModels
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
