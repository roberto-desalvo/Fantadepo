﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Shared.Models
{
    public class PlayerAcquisition
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public int Price { get; set; }
        public int TeamPlayerId { get; set; }
        public TeamPlayer? TeamPlayer { get; set; }
    }
}
