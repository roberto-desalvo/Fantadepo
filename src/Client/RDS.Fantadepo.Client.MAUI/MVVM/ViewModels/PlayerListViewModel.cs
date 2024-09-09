using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RDS.Fantadepo.Client.MAUI.Utilities;
using RDS.Fantadepo.Client.MAUI.MVVM.Views;
using System.Collections.ObjectModel;
using RDS.Fantadepo.Shared.Models;
using RDS.Fantadepo.Client.Business.Services.Abstractions;

namespace RDS.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    public partial class PlayerListViewModel : ObservableObject
    {

        [ObservableProperty]
        private ObservableCollection<PlayerListItemViewModel> players = [];

        private readonly IPlayerService _playerService;

        public PlayerListViewModel(IPlayerService playerService)
        {
            _playerService = playerService ?? throw new ArgumentNullException(nameof(playerService));
            Task.Factory.StartNew(async () => { await LoadData(); });
        }

        private async Task LoadData()
        {
            var teams = await _playerService.GetPlayers();

            foreach (var t in teams.Select(t => new PlayerListItemViewModel(t)))
            {
                Players.Add(t);
            }
        }

        [RelayCommand]
        private void AddPlayer()
        {
            UIHelper.SafeCall(async () =>
            {
                var data = new Dictionary<string, object> { { QueryAttributes.ISREADONLY, false } };
                await Shell.Current.GoToAsync(nameof(PlayerDetailPage), data);
            });
        }

        [RelayCommand]
        public void ModifyPlayer(Player player)
        {
            UIHelper.SafeCall(async () =>
            {
                var data = new Dictionary<string, object> 
                {
                    { QueryAttributes.ISREADONLY, false }, 
                    { QueryAttributes.PLAYERID, player.Id } 
                };
                await Shell.Current.GoToAsync(nameof(PlayerDetailPage), data);
            });
        }
    }
}
