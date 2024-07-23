using RDS.Fantadepo.Business.Models;
using RDS.Fantadepo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly FantadepoContext _context;

        public PlayerService(FantadepoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Player> GetPlayers()
        {
            var entities = _context.Players.ToList();

            foreach (var p in entities)
            {
                yield return new Player
                {
                    Id = p.Id,
                    Nickname = p.Nickname
                };
            }
        }
    }
}
