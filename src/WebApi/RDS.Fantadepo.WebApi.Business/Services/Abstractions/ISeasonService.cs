using RDS.Fantadepo.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Services.Abstractions
{
    public interface ISeasonService
    {
        bool ScheduleTurns(int seasonId);
        bool UpdateSeasonTeams(int seasonId, IList<Team> teams);
    }
}
