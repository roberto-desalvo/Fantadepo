using RDS.Fantadepo.MAUI.MVVM.ViewModels;

namespace RDS.Fantadepo.MAUI.MVVM.Views;

public partial class TeamDetailPage : ContentPage
{
    public TeamDetailPage(TeamDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
    }
}