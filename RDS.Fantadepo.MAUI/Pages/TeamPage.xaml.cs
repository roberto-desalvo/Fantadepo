using AndroidX.Lifecycle;
using RDS.Fantadepo.Business.Models;
using RDS.Fantadepo.MAUI.ViewModels;

namespace RDS.Fantadepo.MAUI.Pages;

[QueryProperty(nameof(PlayerPage.Player), nameof(Business.Models.Player))]
public partial class TeamPage : ContentPage
{
    public Team Team { set => Load(value); }

    public TeamPage(TeamViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
    }

    private void Load(Team value)
    {
        if (this.BindingContext is TeamViewModel model)
        {
            model.Team = value;
        }
    }
}