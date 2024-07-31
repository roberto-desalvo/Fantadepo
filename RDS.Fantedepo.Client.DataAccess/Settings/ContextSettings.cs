using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantedepo.Client.DataAccess.Settings
{
    public class ContextSettings
    {
        public string Scheme { get; set; } = "https";
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public string BasePath {  get; set; } = "api";


    }
}
