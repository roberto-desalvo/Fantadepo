using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RDS.Fantadepo.Business.Models;
using RDS.Fantadepo.MAUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.MAUI.ViewModels
{
    public partial class TeamsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Team> teams = [];

        [RelayCommand]
        public void AddTeam()
        {
            Teams.Add(new Team { Name = $"Insert team name here" });
        }

        public void OnModifyTeamName(Team team)
        {
            team.Name = string.Empty;
        }

    }
}

