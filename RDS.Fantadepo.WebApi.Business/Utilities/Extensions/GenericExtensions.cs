using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Utilities.Extensions
{
    public static class GenericExtensions
    {
        public static bool IsNullOrZero(this int? value)
        {
            return value == null || value == 0;
        }

        public static bool IsTrue(this bool? value)
        {
            return value ?? false;
        }
    }
}
