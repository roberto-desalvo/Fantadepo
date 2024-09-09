using CommunityToolkit.Mvvm.ComponentModel;
using RDS.Fantadepo.Client.Business.Services.Abstractions;
using RDS.Fantadepo.Client.MAUI.Utilities;
using RDS.Fantadepo.Shared.Models;

namespace RDS.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    public partial class PlayerDetailViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private Player? model;

        [ObservableProperty]
        private bool _isReadonly = true;

        private readonly IPlayerService _playerService;

        public PlayerDetailViewModel(IPlayerService playerService)
        {
            _playerService = playerService ?? throw new ArgumentNullException(nameof(playerService));
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            query.TryGetValue(QueryAttributes.PLAYERID, out object? id);

            IsReadonly = query.TryGetValue(QueryAttributes.ISREADONLY, out object? isReadonly) ? (bool)isReadonly : true;
            Task.Factory.StartNew(async () =>
            {
                await LoadData((int?)id);
            });
        }

        private async Task LoadData(int? id)
        {
            Model = id != null 
                ? await _playerService.GetPlayer(id.Value) ?? new()
                : new();
        }
    }
}
