using RDS.Fantadepo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Client.Business.Services.Abstractions
{
    public interface IPlayerService
    {
        Task<Player?> GetPlayer(int id);
        Task<IEnumerable<Player>> GetPlayers();
        Task<int> Save(Player player);
    }
}
