﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Models.DTO
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int CoachId { get; set; }
        public CoachDto Coach { get; set; }

        public int SeasonId { get; set; }
        public SeasonDto Season { get; set; }

        public ICollection<MatchDto> HomeMatches { get; set; }
        public ICollection<MatchDto> AwayMatches { get; set; }
        public ICollection<TeamPlayerDto> TeamPlayers { get; set; }
    }
}
