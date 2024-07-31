using RDS.Fantadepo.MAUI.MVVM.ViewModels;

namespace RDS.Fantadepo.MAUI.MVVM.Views
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
