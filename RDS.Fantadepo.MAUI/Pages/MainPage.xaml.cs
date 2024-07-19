using RDS.Fantadepo.MAUI.ViewModels;

namespace RDS.Fantadepo.MAUI.Pages
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
