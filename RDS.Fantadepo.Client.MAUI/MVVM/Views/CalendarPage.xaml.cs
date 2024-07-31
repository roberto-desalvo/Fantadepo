using RDA.Fantadepo.Client.MAUI.MVVM.ViewModels;

namespace RDA.Fantadepo.Client.MAUI.MVVM.Views
{
    public partial class CalendarPage : ContentPage
    {
        public CalendarPage(CalendarViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }
    }
}
