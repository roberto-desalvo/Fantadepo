using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantedepo.Client.DataAccess.Settings
{
    public class Context
    {
        private readonly ContextSettings _settings;

        public Context(ContextSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public Uri GetFormedUri(string customPath, Dictionary<string, string> parameters)
        {         
            var uriString = $"{_settings.BaseUrl}/{customPath}"; 

            if((parameters?.Count ?? 0) != 0) 
            {
                uriString += "?";
                foreach (var value in parameters!)
                {
                    uriString += $"{value.Key}={value.Value}&";
                }
                uriString = uriString.Remove(uriString.Length - 1, 1);
            }

            return new Uri(uriString);
        }
    }
}
