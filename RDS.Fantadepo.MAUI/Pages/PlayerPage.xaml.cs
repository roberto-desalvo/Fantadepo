using RDS.Fantadepo.Business.Models;
using RDS.Fantadepo.MAUI.ViewModels;

namespace RDS.Fantadepo.MAUI.Pages;

[QueryProperty(nameof(PlayerPage.Player), nameof(Business.Models.Player))]
public partial class PlayerPage : ContentPage
{
    public Player Player { set => Load(value); }    

    public PlayerPage(PlayerViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
    }

    private void Load(Player value)
    {
        if(this.BindingContext is PlayerViewModel model)
        {
            model.Player = value;
        }
    }
}