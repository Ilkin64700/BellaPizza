using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BellaPizza.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace BellaPizza.Models.Context
{
    public class BellaContext : DbContext
    {
        public BellaContext(DbContextOptions<BellaContext> options)
            : base(options)
        { }

        public DbSet<AppDetail>  AppDetails { get; set; }
        public DbSet<Customer>  Customers { get; set; }
        public DbSet<MenuItem>  MenuItems { get; set; }
        public DbSet<MenuItemGroup>  MenuItemGroups { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
