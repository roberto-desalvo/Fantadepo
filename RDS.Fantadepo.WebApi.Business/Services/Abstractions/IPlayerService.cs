using RDS.Fantadepo.Models.Models;

namespace RDS.Fantadepo.WebApi.Business.Services.Abstractions
{
    public interface IPlayerService
    {
        Player? GetPlayer(int id);
        IEnumerable<Player> GetPlayers(Func<Player, bool>? predicate = null);
    }
}
