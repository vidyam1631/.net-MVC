using Microsoft.EntityFrameworkCore;

namespace MVC_CodeFirstDemo.Models
{
    public class ApplicationContext:DbContext

    {
        public ApplicationContext(DbContextOptions<ApplicationContext> context):base(context) {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Catagory> Catagories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catagory>()
                .HasMany(p => p.Prods)
                .WithOne(p => p.Cat)
                .HasForeignKey(p => p.CatId)
                .IsRequired(false);
        }
    }
}
