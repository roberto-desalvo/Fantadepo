using RDS.Fantadepo.Client.MAUI.MVVM.ViewModels;

namespace RDS.Fantadepo.Client.MAUI.MVVM.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();            
            BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }        
    }
}
