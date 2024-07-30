using AutoMapper;
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
    public class PlayerService(FantadepoContext context, IMapper mapper) : BaseService(context, mapper), IPlayerService
    {
        public PlayerDto? GetPlayer(int id)
        {
            var player = _context.Players.Find(id);
            return _mapper.Map<PlayerDto>(player);
        }

        public IEnumerable<PlayerDto> GetPlayers(Func<PlayerDto, bool>? predicate = null)
        {
            Func<PlayerDto, bool> all = x => true;
            return _mapper.Map<IEnumerable<PlayerDto>>(_context.Players).Where(predicate ?? all);
        }
    }
}
