using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using demoDataFirst.Models;

namespace demoDataFirst.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<demoDataFirst.Models.User> User { get; set; } = default!;
        public DbSet<demoDataFirst.Models.Membership> Membership { get; set; } = default!;
        public DbSet<demoDataFirst.Models.Order> Order { get; set; } = default!;
        public DbSet<demoDataFirst.Models.OrderDetail> OrderDetail { get; set; } = default!;
    }
}
