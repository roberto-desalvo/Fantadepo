using RDS.Fantadepo.MAUI.MVVM.ViewModels;
using RDS.Fantadepo.Models.Models;

namespace RDS.Fantadepo.MAUI.MVVM.Views;

[QueryProperty(nameof(PlayerDetailPage.Player), nameof(Models.Models.Player))]
public partial class PlayerDetailPage : ContentPage
{
    public Player Player { set => Load(value); }    

    public PlayerDetailPage(PlayerDetailViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
    }

    private void Load(Player value)
    {
        this.BindingContext = new PlayerDetailViewModel(value);
    }
}