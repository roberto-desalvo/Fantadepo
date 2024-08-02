using CommunityToolkit.Mvvm.ComponentModel;
using RDS.Fantadepo.Client.Business.Services.Abstractions;
using RDS.Fantadepo.Models.Models;

namespace RDS.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    public partial class PlayerListItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private Player? model;
        public int Id { get => Model?.Id ?? 0; private set => Model = new Player { Id = value }; }

        private readonly IPlayerService _playersService;

        public PlayerListItemViewModel(IPlayerService playerService)
        {
            _playersService = playerService ?? throw new ArgumentNullException(nameof(playerService));
            Task.Factory.StartNew(async () => await LoadAsync(null));
        }

        public PlayerListItemViewModel(Player? player)
        {
            Task.Factory.StartNew(async () => await LoadAsync(player));
        }

        public async Task LoadAsync(Player? player)
        {
            Model = (player is null && Id != 0) ? await _playersService.GetPlayer(Id) : player;
        }
    }
}
