using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Models.DTO
{
    public class FieldedTeamPlayerDto
    {
        public int Id { get; set; }
        public int TeamPlayerId { get; set; }
        public TeamPlayerDto TeamPlayer { get; set; }
        public int MatchId { get; set; }
        public MatchDto Match { get; set; }
    }
}
