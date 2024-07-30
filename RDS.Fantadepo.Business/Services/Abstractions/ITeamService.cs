using RDS.Fantadepo.WebApi.Business.Models;
using RDS.Fantadepo.WebApi.Business.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Services.Abstractions
{
    public interface ITeamService
    {
        TeamDto? GetTeam(int id);
        IEnumerable<TeamDto> GetTeams(Func<TeamDto, bool>? predicate = null);
        IEnumerable<TeamDto> GetTeamsWithCoaches();
        TeamDto? GetTeamWithCoach(int id);
    }
}
