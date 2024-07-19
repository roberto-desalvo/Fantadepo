﻿using CommunityToolkit.Mvvm.ComponentModel;
using RDS.Fantadepo.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.MAUI.ViewModels
{
    public partial class PlayerViewModel : ObservableObject
    {
        [ObservableProperty]
        private Player player = new();
        
    }
}
