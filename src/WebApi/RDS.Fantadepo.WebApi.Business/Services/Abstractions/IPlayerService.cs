using RDS.Fantadepo.Shared.Models;
using RDS.Fantadepo.Shared.Models.SearchCriteria;

namespace RDS.Fantadepo.WebApi.Business.Services.Abstractions
{
    public interface IPlayerService
    {
        Task<int> CreatePlayer(Player Player);
        Task<bool> DeletePlayer(int id);
        Task<Player?> GetPlayer(int id);
        Task<IEnumerable<Player>> GetPlayers(PlayerSearchCriteria searchCriteria);
        Task<bool> UpdatePlayer(int id, Player Player);
    }
}
