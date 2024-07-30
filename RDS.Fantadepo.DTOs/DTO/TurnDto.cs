using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Models.DTO
{
    public class TurnDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly Date { get; set; }

        public int SeasonId { get; set; }
        public SeasonDto Season { get; set; }

        public ICollection<MatchDto> Matches { get; set; }
        public ICollection<PlayerPerformanceDto> PlayerPerformances { get; set; }
    }
}
