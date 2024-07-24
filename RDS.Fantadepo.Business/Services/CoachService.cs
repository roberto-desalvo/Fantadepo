using AutoMapper;
using RDS.Fantadepo.Business.Models;
using RDS.Fantadepo.Business.Services.Abstractions;
using RDS.Fantadepo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Services
{
    public class CoachService(FantadepoContext context, IMapper mapper) : BaseService(context, mapper), ICoachService
    {
        public Coach? GetCoach(int id)
        {
            return _mapper.Map<Coach>(_context.Coaches.Find(id));
        }
    }
}
