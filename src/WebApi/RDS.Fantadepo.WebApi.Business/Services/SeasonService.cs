using AutoMapper;
using RDS.Fantadepo.Shared.Models;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;
using RDS.Fantadepo.WebApi.DataAccess;
using Entities = RDS.Fantadepo.WebApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDS.Fantadepo.WebApi.Business.Helpers;

namespace RDS.Fantadepo.WebApi.Business.Services
{
    public class SeasonService(FantadepoContext context, IMapper mapper) : BaseService(context, mapper), ISeasonService
    {
        public bool UpdateSeasonTeams(int seasonId, IList<Team> teams)
        {
            var season = _context.Seasons.FirstOrDefault(s => s.Id == seasonId);
            if(season == null)
            {
                return false;
            }

            season.Teams = _mapper.Map<IList<Entities.Team>>(teams);
            _context.SaveChanges();
            return true;
        }

        public bool ScheduleTurns(int seasonId)
        {
            var season = _context.Seasons.FirstOrDefault(s => s.Id == seasonId);
            if(season == null)
            {
                return false;
            }

            season = CalendarHelper.ScheduleTurns(season);
            _context.SaveChanges();
            return true;
        }
    }
}
