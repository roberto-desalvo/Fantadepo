using RDA.Fantadepo.Client.MAUI.MVVM.ViewModels;

namespace RDA.Fantadepo.Client.MAUI.MVVM.Views
{
    public partial class TeamListPage : ContentPage
    {
        public TeamListPage(TeamListViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }
    }
}
