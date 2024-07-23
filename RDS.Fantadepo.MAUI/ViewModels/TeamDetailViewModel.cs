using CommunityToolkit.Mvvm.ComponentModel;
using RDS.Fantadepo.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.MAUI.ViewModels
{
    public partial class TeamDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _name = string.Empty;

        public TeamDetailViewModel()
        {
            
        }

        public TeamDetailViewModel(Team team)
        {
            _name = team.Name;
        }
    }
}
