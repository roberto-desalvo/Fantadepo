using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.MAUI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string text = "this is a test";

        [RelayCommand]
        public void OpenTeamsPage()
        {

        }

        [RelayCommand]
        public void OpenCalendarPage()
        {

        }

        [RelayCommand]
        public void OpenPlayersPage()
        {

        }
    }
}
