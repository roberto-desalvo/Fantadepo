using RDS.Fantadepo.Client.MAUI.MVVM.ViewModels;

namespace RDS.Fantadepo.Client.MAUI.MVVM.Views;

public partial class TeamDetailPage : ContentPage
{
    public TeamDetailPage(TeamDetailViewModel viewModel)
    {
		try
		{
			InitializeComponent();
			BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
		}
		catch (Exception ex)
		{

			throw;
		}
    }
}