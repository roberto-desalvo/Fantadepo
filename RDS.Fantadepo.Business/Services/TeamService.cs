using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RDS.Fantadepo.WebApi.Business.Models;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;
using RDS.Fantadepo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDS.Fantadepo.WebApi.Business.Models.DTO;

namespace RDS.Fantadepo.WebApi.Business.Services
{
    public class TeamService(FantadepoContext context, IMapper mapper) : BaseService(context, mapper), ITeamService
    {
        public TeamDto? GetTeam(int id)
        {
            var team = _context.Teams.Find(id);
            return _mapper.Map<TeamDto>(team);
        }

        public IEnumerable<TeamDto> GetTeams(Func<TeamDto, bool>? predicate = null)
        {
            Func<TeamDto, bool> all = x => true;
            return _mapper.Map<IEnumerable<TeamDto>>(_context.Teams).Where(predicate ?? all);
        }

        public IEnumerable<TeamDto> GetTeamsBySeason(int seasonId)
        {
            return _context.Teams
                .Where(x => x.SeasonId == seasonId)
                .Select(_mapper.Map<TeamDto>);
        }

        public IEnumerable<TeamDto> GetTeamsWithCoaches()
        {
            return _mapper.Map<IEnumerable<TeamDto>>(_context.Teams.Include(x => x.Coach));
        }

        public TeamDto? GetTeamWithCoach(int id)
        {
            return _mapper.Map<TeamDto>(_context.Teams.Include(x => x.Coach).FirstOrDefault(x => x.Id == id));
        }
    }
}
