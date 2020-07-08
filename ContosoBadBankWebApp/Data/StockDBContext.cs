using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContosoBadBank.Models
{


    public class StockDBContext : DbContext
    {
        public StockDBContext(DbContextOptions<StockDBContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<DepotEntry> DepotEntries { get; set; }

    }
}