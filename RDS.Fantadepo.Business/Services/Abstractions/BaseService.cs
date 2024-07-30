using AutoMapper;
using RDS.Fantadepo.WebApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Services.Abstractions
{
    public abstract class BaseService
    {
        protected readonly FantadepoContext _context;
        protected readonly IMapper _mapper;

        public BaseService(FantadepoContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper= mapper?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
