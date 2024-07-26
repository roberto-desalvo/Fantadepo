﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }

        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; } = new();
        public decimal? HomeTeamScore { get; set; }

        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; } = new();
        public decimal? AwayTeamScore { get; set; }

        public int TurnId { get; set; }
        public Turn Turn { get; set; } = new();

        public ICollection<FieldedTeamPlayer> FieldedTeamPlayers { get; set; } = [];
    }

}
