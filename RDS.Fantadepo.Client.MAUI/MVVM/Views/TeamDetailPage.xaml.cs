using RDA.Fantadepo.Client.MAUI.MVVM.ViewModels;

namespace RDA.Fantadepo.Client.MAUI.MVVM.Views;

public partial class TeamDetailPage : ContentPage
{
    public TeamDetailPage(TeamDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
    }
}