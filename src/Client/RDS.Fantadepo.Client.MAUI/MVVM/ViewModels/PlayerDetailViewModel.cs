using CommunityToolkit.Mvvm.ComponentModel;
using RDS.Fantadepo.Client.MAUI.Utilities;
using RDS.Fantadepo.Shared.Models;

namespace RDS.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    [QueryProperty(nameof(Id), QueryAttributes.PLAYERID)]
    [QueryProperty(nameof(IsReadonly), QueryAttributes.ISREADONLY)]
    public partial class PlayerDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private Player? model;
        public int Id { get => model?.Id ?? 0; private set => model = new Player { Id = value }; }

        [ObservableProperty]
        private bool _isReadonly = true;
      

        public PlayerDetailViewModel(Player? player)
        {
            model = player;
        }

    }
}
