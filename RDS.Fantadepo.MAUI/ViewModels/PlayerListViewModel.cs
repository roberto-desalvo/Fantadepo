using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RDS.Fantadepo.Business.Models;
using RDS.Fantadepo.Business.Services;
using RDS.Fantadepo.DataAccess;
using RDS.Fantadepo.MAUI.Models;
using RDS.Fantadepo.MAUI.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.MAUI.ViewModels
{
    public partial class PlayerListViewModel : ObservableObject
    {
        private readonly IPlayerService _playerService;

        [ObservableProperty]
        private ObservableCollection<Player> players = [];

        public PlayerListViewModel(IPlayerService playerService)
        {
            _playerService = playerService?? throw new ArgumentNullException(nameof(playerService));
            Players = new(playerService.GetPlayers());
        }

        [RelayCommand]
        private void AddPlayer()
        {
            UIHelper.SafeCall(async () =>
            {
                var player = new Player { Name = "Insert player name" };
                var data = new Dictionary<string, object> { { nameof(Player), player } };
                await Shell.Current.GoToAsync(nameof(PlayerPage), data);
                Players.Add(player);
            });
        }

        public void OnModifyPlayer(Player player)
        {
            UIHelper.SafeCall(async () =>
            {
                var data = new Dictionary<string, object> { { nameof(Player), player } };
                await Shell.Current.GoToAsync(nameof(PlayerPage), data);
            });            
        }
    }
}
