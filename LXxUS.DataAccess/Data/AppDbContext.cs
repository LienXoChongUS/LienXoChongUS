
using LXxUS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LXxUS.DataAccess.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Category> Categories { get; set; }
		public DbSet<Category> Books { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Category>().HasData(
				new Category { Id = 1, Name = "Action", Description = "Funny", DisplayOrder = 1 },
				new Category { Id = 2, Name = "SciFi", Description = "Funny", DisplayOrder = 2 },
				new Category { Id = 3, Name = "Romance", Description = "Romantic", DisplayOrder = 3 }
				);
		}
    }
}
