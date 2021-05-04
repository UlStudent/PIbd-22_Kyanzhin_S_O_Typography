using TypographyDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace TypographyDatabaseImplement
{
    public class TypographyDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TypographyDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Printed> Printeds { set; get; }
        public virtual DbSet<PrintedComponent> PrintedComponents { set; get; }
        public virtual DbSet<Store> Stores { set; get; }
        public virtual DbSet<StoreComponent> StoreComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
    }
}
