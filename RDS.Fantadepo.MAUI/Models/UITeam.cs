using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RDS.Fantadepo.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.MAUI.Models
{
    public class UITeam 
    {
        public Team Team { get; set; } = new();
        public bool IsReadOnly { get; set; }
        public string TempName { get; set; } = string.Empty;
    }
}
