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
    }
}
