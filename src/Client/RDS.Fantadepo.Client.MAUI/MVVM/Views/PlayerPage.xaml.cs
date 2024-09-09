using RDS.Fantadepo.Client.MAUI.MVVM.ViewModels;
using RDS.Fantadepo.Shared.Models;

namespace RDS.Fantadepo.Client.MAUI.MVVM.Views;

public partial class PlayerDetailPage : ContentPage
{ 
    public PlayerDetailPage(PlayerDetailViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
    }
}