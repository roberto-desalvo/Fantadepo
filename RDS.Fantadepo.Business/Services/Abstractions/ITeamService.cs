using RDS.Fantadepo.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Services.Abstractions
{
    public interface ITeamService
    {
        Team? GetTeam(int id);
        IEnumerable<Team> GetTeams(Func<Team, bool>? predicate = null);

    }
}
