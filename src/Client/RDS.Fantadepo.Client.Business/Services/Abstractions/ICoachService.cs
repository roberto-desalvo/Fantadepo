using RDS.Fantadepo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Client.Business.Services.Abstractions
{
    public interface ICoachService
    {
        Task<Coach?> GetCoach(int id);
        Task<IEnumerable<Coach>> GetCoaches();
        Task<int> Save(Coach coach);
    }
}
