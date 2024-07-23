using CommunityToolkit.Mvvm.ComponentModel;
using RDS.Fantadepo.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.MAUI.ViewModels
{
    public partial class PlayerDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _firstname = string.Empty;
        
        [ObservableProperty]
        private string _lastname = string.Empty;
        
        [ObservableProperty]
        private string _nickname = string.Empty;

        [ObservableProperty]
        private string _firstRole = string.Empty;

        [ObservableProperty]
        private string _secondaryRole = string.Empty;

        public PlayerDetailViewModel()
        {
            
        }

        public PlayerDetailViewModel(Player player)
        {
            _firstname = player.Firstname;
            _lastname = player.Lastname;
            _nickname = player.Nickname;
            _firstRole = player.FirstRole.ToString();
            _secondaryRole = player.SecondaryRole.ToString();
        }
    }
}
