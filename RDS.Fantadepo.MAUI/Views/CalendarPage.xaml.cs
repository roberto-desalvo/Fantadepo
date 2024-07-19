using RDS.Fantadepo.Business.Models;
using RDS.Fantadepo.MAUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.MAUI.Views
{
    public partial class CalendarPage : ContentPage
    {
        public CalendarPage(CalendarViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        public void OnTapGestureRecognizerTapped(object sender, FocusEventArgs e)
        {
            if (sender is Frame frame)
            {
                var label = frame.Children.OfType<Label>().FirstOrDefault() ?? new Label();

                if ((label.BindingContext is Turn turn) && (this.BindingContext is CalendarViewModel model))
                {
                    model.OpenTurn(turn);
                }
            }
        }
    }
}
