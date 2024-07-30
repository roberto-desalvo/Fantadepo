using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RDS.Fantadepo.MAUI.Utilities;
using RDS.Fantadepo.MAUI.MVVM.Views;
using System.Collections.ObjectModel;
using RDS.Fantadepo.Models.Models;

namespace RDS.Fantadepo.MAUI.MVVM.ViewModels
{
    public partial class PlayerListViewModel : ObservableObject
    {
        //private readonly IPlayerService _playerService;

        [ObservableProperty]
        private ObservableCollection<PlayerDetailViewModel> players = [];

        //public PlayerListViewModel(IPlayerService playerService)
        //{
        //    _playerService = playerService ?? throw new ArgumentNullException(nameof(playerService));

        //    var playerList = playerService.GetPlayers().Select(p => new PlayerDetailViewModel(p)).ToList();
        //    Players = new(playerList);
        //}

        [RelayCommand]
        private void AddPlayer()
        {
            UIHelper.SafeCall(async () =>
            {
                var player = new Player { Nickname = "Insert player name" };
                var data = new Dictionary<string, object> { { nameof(Player), player } };
                await Shell.Current.GoToAsync(nameof(PlayerDetailPage), data);
                Players.Add(new PlayerDetailViewModel(player));
            });
        }

        public void OnModifyPlayer(Player player)
        {
            UIHelper.SafeCall(async () =>
            {
                var data = new Dictionary<string, object> { { nameof(Player), player } };
                await Shell.Current.GoToAsync(nameof(PlayerDetailPage), data);
            });
        }
    }
}
