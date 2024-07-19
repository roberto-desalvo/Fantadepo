using Microsoft.EntityFrameworkCore;
using RDS.Fantadepo.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.DataAccess
{
    public class FantadepoContext : DbContext
    {
        public DbSet<PlayerEntity> Players { get; set; }

        public FantadepoContext(DbContextOptions<FantadepoContext> opt) : base(opt)
        {
            
        }
    }
}
