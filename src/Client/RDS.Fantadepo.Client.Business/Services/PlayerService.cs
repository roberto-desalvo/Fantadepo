using RDS.Fantadepo.Client.Business.Services.Abstractions;
using RDS.Fantadepo.Shared.Models;
using RDS.Fantedepo.Client.DataAccess.Repositories.Abstractions;

namespace RDS.Fantadepo.Client.Business.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _repo;

        public PlayerService(IPlayerRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<Player?> GetPlayer(int id)
        {
            return await _repo.Get(id);
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            return await _repo.Get();
        }

        public async Task<int> Save(Player player)
        {
            return await ((player.Id == 0) ? _repo.Create(player) : _repo.Update(player.Id, player));
        }
    }
}
