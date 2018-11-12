using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zadatak9.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        { }
        
        public DbSet<Security> Securities { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Exchange> Exchanges { get; set; }

        public DbSet<Security_Primary_Type> Security_Primary_Types { get; set; }

        public DbSet<Option> Options { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Security>().HasOne(x => x.UnderlyningSecurity).WithMany(x => x.Securities).HasForeignKey(x => x.Underlyning_SID);

            modelBuilder.Entity<Security>().HasOne(x => x.Exchange).WithMany(x => x.Securities).HasForeignKey(x => x.Exchange_ID);

            modelBuilder.Entity<Security>().HasOne(x => x.Currency).WithMany(x => x.Securities).HasForeignKey(x => x.Currency_ID);

            modelBuilder.Entity<Security>().HasOne(x => x.Security_Primary_Type).WithMany(x => x.Securities).HasForeignKey(x => x.Security_Primary_Type_ID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
