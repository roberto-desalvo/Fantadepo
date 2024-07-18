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
        private ObservableCollection<UITeam> teams = [];

        [RelayCommand]
        public void AddTeam()
        {
            Teams.Add(new UITeam { Team = new() { Name = $"Insert team name here" }, IsReadOnly = true });
        }

        public void OnTeamEntryFocused(UITeam uiTeam)
        {
            uiTeam.IsReadOnly = false;

            uiTeam.TempName = uiTeam.Team.Name;
            uiTeam.Team.Name = string.Empty;
        }

        public void OnTeamEntryUnfocused(UITeam uiTeam)
        {
            uiTeam.IsReadOnly = true;

            if (uiTeam.Team.Name == string.Empty && uiTeam.TempName != string.Empty)
            {
                uiTeam.Team.Name = uiTeam.TempName;
                uiTeam.TempName = string.Empty;
            }
        }
    }
}

