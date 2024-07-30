using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Models.DTO
{
    public class PlayerReleaseDto
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public int Price { get; set; }
        public int TeamPlayerId { get; set; }
        public TeamPlayerDto TeamPlayer { get; set; }
    }
}
