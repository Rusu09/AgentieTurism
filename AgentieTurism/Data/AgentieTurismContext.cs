using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AgentieTurism.Models;

namespace AgentieTurism.Data
{
    public class AgentieTurismContext : DbContext
    {
        public AgentieTurismContext (DbContextOptions<AgentieTurismContext> options)
            : base(options)
        {
        }

        public DbSet<AgentieTurism.Models.Vacation> Vacation { get; set; } = default!;
        public DbSet<AgentieTurism.Models.Location> Location { get; set; } = default!;
        public DbSet<AgentieTurism.Models.Tag> Tag { get; set; } = default!;
    }
}
