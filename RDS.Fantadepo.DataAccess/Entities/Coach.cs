using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.DataAccess.Entities
{
    public class Coach
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public Team? Team { get; set; }
    }

    public static class CoachModelCreator
    {
        public static void Configure(ModelBuilder mb)
        {
            mb.Entity<Coach>()
                .HasOne(c => c.Team)
                .WithOne(t => t.Coach)
                .HasForeignKey<Team>(t => t.CoachId);
        }
    }
}
