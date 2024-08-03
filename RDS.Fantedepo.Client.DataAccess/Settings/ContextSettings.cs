using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantedepo.Client.DataAccess.Settings
{
    public class ContextSettings
    {
        public string BaseUrl { get; set; }


        public ContextSettings()
        {
            BaseUrl = "https://fantadepo.azurewebsites.net";
        }
    }
}
