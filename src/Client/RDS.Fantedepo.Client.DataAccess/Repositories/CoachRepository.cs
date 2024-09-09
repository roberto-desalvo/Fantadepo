using RDS.Fantadepo.Shared.Models;
using RDS.Fantedepo.Client.DataAccess.Repositories.Abstractions;
using RDS.Fantedepo.Client.DataAccess.Settings;

namespace RDS.Fantedepo.Client.DataAccess.Repositories
{
    public class CoachRepository : CrudRepository<Coach>, ICoachRepository
    {
        public CoachRepository(Context context) : base(context)
        {
        }
    }
}
