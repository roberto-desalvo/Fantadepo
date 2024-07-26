using CommunityToolkit.Mvvm.ComponentModel;
using RDS.Fantadepo.Business.Models;
using RDS.Fantadepo.Business.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.MAUI.ViewModels
{
    public partial class TeamListItemViewModel : ObservableObject, IQueryAttributable
    {
        private int id;

        [ObservableProperty]
        private string coachFirstName = string.Empty;

        [ObservableProperty]
        private string coachLastName = string.Empty;

        [ObservableProperty]
        private string teamName = string.Empty;

        private readonly ITeamService _teamService;

        public TeamListItemViewModel(ITeamService teamService)
        {
            _teamService = teamService ?? throw new ArgumentNullException(nameof(teamService));
            Load();
        }

        public TeamListItemViewModel(Team team)
        {
            this.TeamName = team.Name;
            this.CoachFirstName = team.Coach.FirstName;
            this.CoachLastName = team.Coach.LastName;
        }

        private void Load()
        {
            if (id != 0)
            {
                var team = _teamService.GetTeamWithCoach(id);
                if (team != null)
                {
                    this.TeamName = team.Name;
                    this.CoachFirstName = team.Coach.FirstName;
                    this.CoachLastName = team.Coach.LastName;
                }
            }
        }


        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            id = query.TryGetValue("TeamId", out object? value) ? (int)value : 0;
        }
    }

}
