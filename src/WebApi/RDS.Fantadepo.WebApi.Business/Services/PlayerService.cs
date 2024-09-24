using AutoMapper;
using RDS.Fantadepo.WebApi.Business.Services.Abstractions;
using RDS.Fantadepo.WebApi.DataAccess;
using Entities = RDS.Fantadepo.WebApi.DataAccess.Entities;
using RDS.Fantadepo.Shared.Models;
using Microsoft.EntityFrameworkCore;
using RDS.Fantadepo.Shared.Models.SearchCriteria;
using RDS.Fantadepo.DataIngestion;

namespace RDS.Fantadepo.WebApi.Business.Services
{
    public class PlayerService(FantadepoContext context, IMapper mapper) : BaseService(context, mapper), IPlayerService
    {
        private bool PlayerExists(int id)
        {
            return _context.Players.Any(e => e.Id == id);
        }

        public async Task<Player?> GetPlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            return _mapper.Map<Player>(player);
        }

        public async Task<IEnumerable<Player>> GetPlayers(PlayerSearchCriteria searchCriteria)
        {
            var query = _context.Players.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchCriteria.NicknamePattern))
            {
                query = query.Where(x => x.Nickname.Contains(searchCriteria.NicknamePattern, StringComparison.CurrentCultureIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(searchCriteria.LastnamePattern))
            {
                query = query.Where(x => x.Nickname.Contains(searchCriteria.LastnamePattern, StringComparison.CurrentCultureIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(searchCriteria.FirstnamePattern))
            {
                query = query.Where(x => x.Nickname.Contains(searchCriteria.FirstnamePattern, StringComparison.CurrentCultureIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(searchCriteria.Include))
            {
                if (searchCriteria.Include.Contains("performances", StringComparison.CurrentCultureIgnoreCase))
                {
                    query = query.Include(x => x.PlayerPerformances);
                }

                if (searchCriteria.Include.Contains("teamplayers", StringComparison.CurrentCultureIgnoreCase))
                {
                    query = query.Include(x => x.TeamPlayers);
                }
            }

            var results = await query.ToListAsync();
            return _mapper.Map<IEnumerable<Player>>(results);
        }

        public async Task<int> CreatePlayer(Player Player)
        {
            var entity = _mapper.Map<Entities.Player>(Player);
            _context.Players.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> DeletePlayer(int id)
        {
            var Player = await _context.Players.FindAsync(id);
            if (Player == null)
            {
                return false;
            }

            var entity = _mapper.Map<Entities.Player>(Player);
            _context.Players.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdatePlayer(int id, Player Player)
        {
            if (id != Player.Id)
            {
                return false;
            }

            if (!PlayerExists(id))
            {
                return false;
            }

            var entity = _mapper.Map<Entities.Player>(Player);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task ImportPlayersFromRosterFile(string path)
        {
            var players = FantadepoExcelFileReader.GetPlayersFromRosterFile(path);

            foreach (var player in players)
            {
                var entityExists = (await _context.Players.FirstOrDefaultAsync(p => p.Firstname == player.Firstname && p.Lastname == player.Lastname))
                    is not null;

                if (!entityExists)
                {
                    var toInsert = _mapper.Map<Entities.Player>(player);
                    await _context.Players.AddAsync(toInsert);
                }
            }

            await _context.SaveChangesAsync();

            return;
        }
        
    }
}
