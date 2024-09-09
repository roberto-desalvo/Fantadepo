using RDS.Fantadepo.Models.Models;
using RDS.Fantadepo.WebApi.Business.Services.SearchCriteria;

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
