﻿using RDS.Fantadepo.Business.Models;
using RDS.Fantadepo.MAUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.MAUI.Views
{
    public partial class TeamListPage : ContentPage
    {
        public TeamListPage(TeamListViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }
    }
}
