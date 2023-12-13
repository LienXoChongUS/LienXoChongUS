using LienXoChongUS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LienXoChongUS.Data
{
	public class AppDbContext : IdentityDbContext<IdentityUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Category> Books { get; set; }
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
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
