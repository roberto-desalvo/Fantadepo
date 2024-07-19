using RDS.Fantadepo.Business.Models;
using RDS.Fantadepo.MAUI.ViewModels;

namespace RDS.Fantadepo.MAUI.Views;

[QueryProperty(nameof(PlayerDetailPage.Player), nameof(Business.Models.Player))]
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
        if(this.BindingContext is PlayerDetailViewModel model)
        {
            model.Player = value;
        }
    }
}