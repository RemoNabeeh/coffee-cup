using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CoffeeCup.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CoffeeType> CoffeeTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Table names match entity names by default (don't pluralize)
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Globally disable the convention for cascading deletes
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Customer>()
                        .Property(c => c.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
