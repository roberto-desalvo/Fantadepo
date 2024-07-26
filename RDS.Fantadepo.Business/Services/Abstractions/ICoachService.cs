using RDS.Fantadepo.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Services.Abstractions
{
    public interface ICoachService
    {
        public Coach? GetCoach(int id);
    }
}
