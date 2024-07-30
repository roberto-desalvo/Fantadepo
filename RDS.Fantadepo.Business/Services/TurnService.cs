using AutoMapper;
using RDS.Fantadepo.WebApi.Business.Models;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;
using RDS.Fantadepo.WebApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDS.Fantadepo.WebApi.Business.Models.DTO;

namespace RDS.Fantadepo.WebApi.Business.Services
{
    public class TurnService(FantadepoContext context, IMapper mapper) : BaseService(context, mapper), ITurnService
    {
        public void CalculatePerformancesForTurn(TurnDto turn)
        {
            //var performances = _context.PlayerPerformances.Where(x => x.TurnId == turn.Id).ToList();

            //foreach(var p in performances)
            //{
            //    var score = PerformanceService.CalculatePerformance(_mapper.Map<PlayerPerformance>(p));
            //    if(score == 0)
            //    {
            //        throw new Exception($"Cannot calculate performance for player {p.Player.Player.Nickname} in turn {turn.Date}");
            //    }

            //    p.Sum = score;
            //}

            //_context.SaveChanges();
        }
    }
}
