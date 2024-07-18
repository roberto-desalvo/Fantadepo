using RDS.Fantadepo.Business.Models;
using RDS.Fantadepo.MAUI.Models;
using RDS.Fantadepo.MAUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.MAUI.Pages
{
    public partial class TeamListPage : ContentPage
    {
        public TeamListPage(TeamListViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        private void OnTapGestureRecognizerDoubleTapped(object sender, FocusEventArgs e)
        {
            if(sender is Frame frame)
            {
                var entry = frame.Children.FirstOrDefault(x => x is Entry) ?? new Entry();

                if(entry.BindingContext is Team team)
                {
                    (this.BindingContext as TeamListViewModel)!.OnModifyTeamName(team);
                }
            }
        }
    }
}
