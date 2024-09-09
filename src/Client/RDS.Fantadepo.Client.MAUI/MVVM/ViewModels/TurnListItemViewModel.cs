using CommunityToolkit.Mvvm.ComponentModel;
using RDS.Fantadepo.Shared.Models;
using System.Collections.ObjectModel;

namespace RDS.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    public partial class TurnListItemViewModel : ObservableObject
    {
        private Turn? model;
        public int Id { get => model?.Id ?? 0; private set => model = new Turn { Id = value }; }

        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private ObservableCollection<MatchListItemViewModel> _matches = [];

        public TurnListItemViewModel(Turn? turn)
        {
            model = turn;
            _name = turn?.Name ?? string.Empty;
        }
    }
}