
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Models.DTO
{
    public class MatchDto
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }

        public int HomeTeamId { get; set; }
        public TeamDto HomeTeam { get; set; }
        public decimal? HomeTeamScore { get; set; }

        public int AwayTeamId { get; set; }
        public TeamDto AwayTeam { get; set; }
        public decimal? AwayTeamScore { get; set; }

        public int TurnId { get; set; }
        public TurnDto Turn { get; set; }

        public ICollection<FieldedTeamPlayerDto> FieldedTeamPlayers { get; set; }
    }

}
