using LienXoChongUS.Models;
using Microsoft.EntityFrameworkCore;

namespace LienXoChongUS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", Description = "Funny", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", Description = "Funny", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Romance", Description = "Romantic", DisplayOrder = 3 }
                ); 
        }
    }
}
