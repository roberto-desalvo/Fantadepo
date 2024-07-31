using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantedepo.Client.DataAccess.Helpers
{
    public static class ApiHelper
    {
        public static Dictionary<string, string> ToStringDictionary(params (string Key, object? Value)[] values)
        {
            return ToStringDictionary(false, values);
        }

        public static Dictionary<string, string> ToStringDictionary(bool includeNull, params (string Key, object? Value)[] values)
        {
            Dictionary<string, string> dict = [];

            foreach (var value in values)
            {
                if (value.Value == null && !includeNull)
                {
                    continue;
                }
                dict.Add(value.Key, value.Value?.ToString() ?? string.Empty);
            }
            return dict;
        }

        public static string GetCustomPath()
        {
            var stackTrace = new StackTrace();
            var frame = stackTrace.GetFrame(2);
            var classType = frame?.GetMethod()?.DeclaringType;
            var className = nameof(classType);
            var customPath = className.Replace("Repository", string.Empty).ToLower().Trim();
            return customPath;
        }
    }
}
