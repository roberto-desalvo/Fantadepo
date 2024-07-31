using RDS.Fantadepo.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Services
{
    public static class TeamFilters
    {
        public static Func<Team, bool> TeamBySeason(int seasonId) =>
            (t) => t.SeasonId == seasonId;
    }
}
