using RDA.Fantadepo.Client.MAUI.MVVM.ViewModels;
using RDS.Fantadepo.Models.Models;

namespace RDA.Fantadepo.Client.MAUI.MVVM.Views;

[QueryProperty(nameof(PlayerDetailPage.Player), nameof(Player))]
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