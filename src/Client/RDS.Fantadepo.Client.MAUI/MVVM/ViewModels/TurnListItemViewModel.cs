using CommunityToolkit.Mvvm.ComponentModel;
using RDS.Fantadepo.Shared.Models;
using System.Collections.ObjectModel;

namespace RDS.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    public partial class TurnListItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private Turn? model;

        public TurnListItemViewModel(Turn? turn)
        {
            Model = turn;
        }
    }
}