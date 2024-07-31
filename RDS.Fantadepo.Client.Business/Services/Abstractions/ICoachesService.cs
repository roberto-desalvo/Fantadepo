using RDS.Fantadepo.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Client.Business.Services.Abstractions
{
    public interface ICoachesService
    {
        Task<Coach?> GetCoach(int id);
        Task<IEnumerable<Coach>> GetCoaches();
    }
}
