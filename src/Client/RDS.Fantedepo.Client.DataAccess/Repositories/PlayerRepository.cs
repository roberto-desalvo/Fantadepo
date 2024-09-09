using RDS.Fantadepo.Shared.Models;
using RDS.Fantedepo.Client.DataAccess.Repositories.Abstractions;
using RDS.Fantedepo.Client.DataAccess.Settings;

namespace RDS.Fantedepo.Client.DataAccess.Repositories
{
    public class PlayerRepository : CrudRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(Context context) : base(context)
        {
        }
    }
}
