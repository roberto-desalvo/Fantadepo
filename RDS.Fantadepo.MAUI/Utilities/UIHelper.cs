using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RDS.Fantadepo.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.MAUI.Utilities
{
    public static class UIHelper 
    {
        public static void SafeCall(Action action)
        {
            try
            {
                action();
            }
            catch(Exception ex) 
            { 
                Shell.Current.DisplayAlert("Exception occurred", ex.Message, string.Empty);
            }

        }
    }
}
