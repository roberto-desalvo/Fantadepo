using RDS.Fantadepo.Client.MAUI.MVVM.ViewModels;
using RDS.Fantadepo.Shared.Models;

namespace RDS.Fantadepo.Client.MAUI.MVVM.Views
{
    public partial class PlayerListPage : ContentPage
    {
        public PlayerListPage(PlayerListViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }
    }
}

