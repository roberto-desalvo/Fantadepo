using CommunityToolkit.Mvvm.ComponentModel;
using RDS.Fantadepo.Client.Business.Services.Abstractions;
using RDS.Fantadepo.Shared.Models;

namespace RDS.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    public partial class PlayerListItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private Player? model;        

        public PlayerListItemViewModel(Player? player)
        {
            Model = player;
        }
    }
}
