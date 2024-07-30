using RDS.Fantadepo.WebApi.Business.Models;
using RDS.Fantadepo.WebApi.Business.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Services.Abstractions
{
    public interface IPlayerService
    {
        PlayerDto? GetPlayer(int id);
        IEnumerable<PlayerDto> GetPlayers(Func<PlayerDto, bool>? predicate = null);
    }
}
