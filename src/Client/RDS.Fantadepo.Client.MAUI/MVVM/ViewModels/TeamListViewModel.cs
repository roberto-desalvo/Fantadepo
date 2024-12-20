﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using RDS.Fantadepo.Client.MAUI.MVVM.Views;
using RDS.Fantadepo.Client.MAUI.Utilities;
using RDS.Fantadepo.Client.Business.Services.Abstractions;
using RDS.Fantadepo.MAUI.Messages;
using RDS.Fantadepo.Shared.Models;
using System.Collections.ObjectModel;

namespace RDS.Fantadepo.Client.MAUI.MVVM.ViewModels
{
    public partial class TeamListViewModel : ObservableObject, IRecipient<TeamAddedMessage>
    {
        [ObservableProperty]
        private ObservableCollection<TeamListItemViewModel> teams = [];

        private readonly ITeamService _teamService;

        public TeamListViewModel(ITeamService teamService)
        {
            _teamService = teamService ?? throw new ArgumentNullException(nameof(teamService));
            Task.Factory.StartNew(async () => { await LoadData(); });

            WeakReferenceMessenger.Default.Register(this);
        }

        private async Task LoadData()
        {
            var teams = await _teamService.GetTeams(AppBusinessContext.CurrentSeason.Id, true);

            foreach (var t in teams.Select(t => new TeamListItemViewModel(t)))
            {
                Teams.Add(t);
            }
        }

        public void Receive(TeamAddedMessage message)
        {
            Team? team = null;
            if(message.Team != null)
            {
                team = message.Team;                
            }
            else if (message.Id != 0)
            {
                Task.Factory.StartNew(async () => { team = await _teamService.GetTeam(message.Id, true); });
            }

            if(team != null)
            {
                Teams.Add(new TeamListItemViewModel(team));
            }
        }

        [RelayCommand]
        public void AddTeam()
        {
            UIHelper.SafeCall(async () =>
            {
                var data = new Dictionary<string, object> { { QueryAttributes.ISREADONLY, false } };
                await Shell.Current.GoToAsync(nameof(TeamDetailPage), data);
            });
        }
    }
}

