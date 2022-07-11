using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSProject
{
    public class SQLiteContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Extra> Extra { get; set; }
        public DbSet<Drink> Drink { get; set; }
        public DbSet<Customer_pizza> Customer_Pizza { get; set; }
        public DbSet<Customer_extra> Customer_Extras { get; set; }
        public DbSet<Customer_drink> Customer_Drinks { get; set; }
        public DbSet<Customer_order> Customer_Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source = db.sqlite");
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer_pizza>()
                    .HasOne(x => x.Pizza)
                    .WithMany(x => x.Pizzas)
                    .HasForeignKey(x => x.PizzaID)
                    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Customer_pizza>()
                   .HasOne(x => x.Customer_order)
                   .WithMany(x => x.customer_Pizzas)
                   .HasForeignKey(x => x.customerOrderID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
