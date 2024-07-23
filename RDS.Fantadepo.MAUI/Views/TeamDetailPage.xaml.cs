using RDS.Fantadepo.Business.Models;
using RDS.Fantadepo.MAUI.ViewModels;

namespace RDS.Fantadepo.MAUI.Views;

[QueryProperty(nameof(TeamDetailPage.Team), nameof(Business.Models.Team))]
public partial class TeamDetailPage : ContentPage
{
    public Team Team { set => Load(value); }

    public TeamDetailPage(TeamDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
    }

    private void Load(Team value)
    {
        this.BindingContext = new TeamDetailViewModel(value);
    }
}