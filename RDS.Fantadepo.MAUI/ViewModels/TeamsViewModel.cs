﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RDS.Fantadepo.Business.Models;
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
        private int i = 0;

        [RelayCommand]
        public void AddTeam()
        {
            Teams.Add(new Team { Name = $"Test {i}" });
            i++;
        }
    }
}
