using RDS.Fantadepo.Business.Models;
using RDS.Fantadepo.MAUI.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
