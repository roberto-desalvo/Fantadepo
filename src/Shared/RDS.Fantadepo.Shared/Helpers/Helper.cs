using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Shared.Helpers
{
    public static class Helper
    {
        public static Dictionary<string, string> ToStringDictionary(bool ignoreNullValues = true, params (string Key, object? Value)[] values)
        {
            Dictionary<string, string> dict = [];

            foreach (var value in values)
            {
                if(ignoreNullValues && value.Value == null)
                {
                    continue;
                }
                dict.Add(value.Key, value.Value?.ToString() ?? string.Empty);
            }
            return dict;
        }
    }
}
