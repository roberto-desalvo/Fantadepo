using RDS.Fantadepo.Business.Models;
using RDS.Fantadepo.MAUI.ViewModels;

namespace RDS.Fantadepo.MAUI.Pages;

[QueryProperty(nameof(ModifyPlayerPage.Player), nameof(Business.Models.Player))]
public partial class ModifyPlayerPage : ContentPage
{
    public Player Player { set => Load(value); }    

    public ModifyPlayerPage(ModifyPlayerViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
    }

    private void Load(Player value)
    {
        if(this.BindingContext is ModifyPlayerViewModel model)
        {
            model.Player = value;
        }
    }
}