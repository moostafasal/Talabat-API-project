using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites;
using Talabat.core.Entites.OrderAgregt;
using TalabatReposatrey.Data.Config;

namespace TalabatReposatrey.Data
{
    public class StoreContext:DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("")
        //}
        public StoreContext(DbContextOptions<StoreContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());




        }

        public DbSet<product> products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Productbrand> productbrands { get; set; }

        public DbSet<DelveryMethod> DeliveryMethods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        



    }
}
