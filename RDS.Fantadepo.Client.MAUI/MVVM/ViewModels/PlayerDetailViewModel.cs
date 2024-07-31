using CommunityToolkit.Mvvm.ComponentModel;
using RDS.Fantadepo.Models.Models;

namespace RDA.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    public partial class PlayerDetailViewModel : ObservableObject
    {
        private Player? model;
        public int Id { get => model?.Id ?? 0; }
        [ObservableProperty]
        private string _firstname = string.Empty;
        
        [ObservableProperty]
        private string _lastname = string.Empty;
        
        [ObservableProperty]
        private string _nickname = string.Empty;       

        public PlayerDetailViewModel(Player? player)
        {
            model = player;
            _firstname = player?.Firstname ?? string.Empty;
            _lastname = player?.Lastname ?? string.Empty;
            _nickname = player?.Nickname ?? string.Empty;
        }
    }
}
