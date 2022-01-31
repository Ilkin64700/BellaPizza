using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BellaPizza.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BellaPizza.Models.Context
{
    public class BellaContext : IdentityDbContext<AppUser>
    {
        public BellaContext(DbContextOptions<BellaContext> options)
            : base(options)
        { }

        public virtual DbSet<AppDetail> AppDetails { get; set; }
        public virtual DbSet<HomeSlider> HomeSliders { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<MenuItemGroup> MenuItemGroups { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<Birthday> Birthdays { get; set; }
        public virtual DbSet<MasterClass> MasterClasses { get; set; }
        public virtual DbSet<ChildrenParty> ChildrenParties { get; set; }
        public virtual DbSet<ContactUs> ContactUs { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<MealSlider> MealSliders { get; set; }
        public virtual DbSet<AboutPagePoints> AboutPagePoints { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<LoyalProgram> LoyalPrograms { get; set; }
        public virtual DbSet<WhatsappOrder> WhatsappOrders { get; set; }
        public virtual DbSet<NewPizza> NewPizzas { get; set; }


    }
}
