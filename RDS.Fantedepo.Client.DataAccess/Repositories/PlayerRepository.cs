using RDS.Fantadepo.Models.Models;
using RDS.Fantedepo.Client.DataAccess.Helpers;
using RDS.Fantedepo.Client.DataAccess.Repositories.Abstractions;
using RDS.Fantedepo.Client.DataAccess.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantedepo.Client.DataAccess.Repositories
{
    public class PlayerRepository : CrudRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(Context context) : base(context)
        {
            customPath = ApiHelper.GetCustomPath();
        }
    }
}
