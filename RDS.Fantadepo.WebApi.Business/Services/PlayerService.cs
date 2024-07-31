using AutoMapper;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;
using RDS.Fantadepo.WebApi.DataAccess;
using RDS.Fantadepo.Models.Models;

namespace RDS.Fantadepo.WebApi.Business.Services
{
    public class PlayerService(FantadepoContext context, IMapper mapper) : BaseService(context, mapper), IPlayerService
    {
        public Player? GetPlayer(int id)
        {
            var player = _context.Players.Find(id);
            return _mapper.Map<Player>(player);
        }

        public IEnumerable<Player> GetPlayers(Func<Player, bool>? predicate = null)
        {
            Func<Player, bool> all = x => true;
            return _mapper.Map<IEnumerable<Player>>(_context.Players).Where(predicate ?? all);
        }
    }
}
