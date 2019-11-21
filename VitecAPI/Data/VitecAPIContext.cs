using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VitecAPI.Models
{
    public class VitecAPIContext : DbContext
    {
        public VitecAPIContext (DbContextOptions<VitecAPIContext> options)
            : base(options)
        {
        }

        public DbSet<VitecAPI.Models.Product> Product { get; set; }
        public DbSet<VitecAPI.Models.Subscription> Subscription { get; set; }
    }
}
