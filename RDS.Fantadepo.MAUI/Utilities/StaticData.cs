using RDS.Fantadepo.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.MAUI
{
    public static class StaticData
    {
        public static Season CurrentSeason { get; set; } = new();
    }
}
