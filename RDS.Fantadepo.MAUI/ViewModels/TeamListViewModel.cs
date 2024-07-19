using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RDS.Fantadepo.Business.Models;
using RDS.Fantadepo.MAUI.Models;
using RDS.Fantadepo.MAUI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.MAUI.ViewModels
{
    public partial class TeamListViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<TeamDetailViewModel> teams = [];

        [RelayCommand]
        public void AddTeam()
        {
            UIHelper.SafeCall(async () =>
            {
                var team = new Team { Name = "Insert team name" };
                var data = new Dictionary<string, object> { { nameof(Team), team } };
                await Shell.Current.GoToAsync(nameof(TeamDetailPage), data);
                Teams.Add(team);
            });
        }

        public void OnModifyTeamName(Team team)
        {
            UIHelper.SafeCall(async () =>
            {
                var data = new Dictionary<string, object> { { nameof(Player), team } };
                await Shell.Current.GoToAsync(nameof(TeamDetailPage), data);
            });
        }

    }
}

