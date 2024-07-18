using RDS.Fantadepo.MAUI.Models;
using RDS.Fantadepo.MAUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.MAUI.Pages
{
    public partial class TeamsPage : ContentPage
    {
        public TeamsPage(TeamsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        private void OnTeamEntryFocused(object sender, FocusEventArgs e)
        {
            if (((Entry)sender).BindingContext is UITeam)
            {
                (this.BindingContext as TeamsViewModel)!.OnTeamEntryFocused((UITeam)((Entry)sender).BindingContext);
            }
        }

        private void OnTeamEntryUnfocused(object sender, FocusEventArgs e)
        {
            if (((Entry)sender).BindingContext is UITeam)
            {
                (this.BindingContext as TeamsViewModel)!.OnTeamEntryUnfocused((UITeam)((Entry)sender).BindingContext);
            }
        }
    }
}
