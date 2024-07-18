﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RDS.Fantadepo.Business.Models;
using RDS.Fantadepo.MAUI.Models;
using RDS.Fantadepo.MAUI.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.MAUI.ViewModels
{
    public partial class PlayersViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Player> players = [];

        [RelayCommand]
        private void AddPlayer()
        {
            UIHelper.SafeCall(async () =>
            {
                var player = new Player { Name = "Insert player name" };
                var data = new Dictionary<string, object> { { nameof(Player), player } };
                await Shell.Current.GoToAsync(nameof(ModifyPlayerPage), data);
                Players.Add(player);
            });
        }

        public void OnModifyPlayer(Player player)
        {
            UIHelper.SafeCall(async () =>
            {
                var data = new Dictionary<string, object> { { nameof(Player), player } };
                await Shell.Current.GoToAsync(nameof(ModifyPlayerPage), data);
            });            
        }
    }
}
