using RDS.Fantadepo.Client.Business.Services.Abstractions;
using RDS.Fantadepo.Models.Models;
using RDS.Fantedepo.Client.DataAccess.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Client.Business.Services
{
    public class CoachesService : ICoachesService
    {
        private readonly ICoachesRepository _repo;

        public CoachesService(ICoachesRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<Coach?> GetCoach(int id)
        {
            return await _repo.Get(id);
        }

        public async Task<IEnumerable<Coach>> GetCoaches()
        {
            return await _repo.Get();
        }

        public async Task Save(Coach coach)
        {
            if (coach.Id == 0)
            {
                await _repo.Create(coach);
            }
            else
            {
                await _repo.Update(coach.Id, coach);
            }
        }
    }
}
