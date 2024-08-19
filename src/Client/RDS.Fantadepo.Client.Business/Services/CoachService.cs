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
    public class CoachService : ICoachService
    {
        private readonly ICoachRepository _repo;

        public CoachService(ICoachRepository repo)
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

        public async Task<int> Save(Coach coach)
        {
            return await ((coach.Id == 0) ? _repo.Create(coach) : _repo.Update(coach.Id, coach));
        }
    }
}
