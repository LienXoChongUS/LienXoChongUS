//Namespace và Using Statements:
using LXxUS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LXxUS.DataAccess.Data
{
//Khai báo lớp AppDbContext:một lớp kế thừa từ IdentityDbContext<IdentityUser>,dành cho quản lý người dùng và bảo mật.
    public class AppDbContext : IdentityDbContext<IdentityUser>
	{
 //Constructor:  nhận DbContextOptions<AppDbContext> để cấu hình cơ sở dữ liệu thông qua Dependency Injection.
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
	
		}
//Khai báo DbSet cho các loại đối tượng: đại diện cho mỗi bảng trong cơ sở dữ liệu.
		public DbSet<Category> Categories { get; set; }
		public DbSet<Book> Books { get; set; }
	        public DbSet<Request> Requests { get; set; }
	        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
	        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
	        public DbSet<OrderHeader> OrderHeaders { get; set; }
	        public DbSet<OrderDetail> OrderDetails  { get; set; }
	 
	 //Phương thức OnModelCreating: ghi đè từ lớp cơ sở (IdentityDbContext) để cấu hình mô hình cơ sở dữ liệu, bao gồm việc đặt ràng buộc, quan hệ, và thêm dữ liệu mẫu. 
  	 //thêm dữ liệu mẫu cho Category và Book.
	        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		//gọi phương thức OnModelCreating của lớp cơ sở (IdentityDbContext), bảo đảm rằng cấu hình mô hình của IdentityDbContext được thực hiện.
			base.OnModelCreating(modelBuilder);
		//Thêm dữ liệu mẫu cho bảng Category:
			modelBuilder.Entity<Category>().HasData(
				new Category { Id = 1, Name = "Action", Description = "Funny", DisplayOrder = 1 },
				new Category { Id = 2, Name = "SciFi", Description = "Funny", DisplayOrder = 2 },
				new Category { Id = 3, Name = "Romance", Description = "Romantic", DisplayOrder = 3 }
				);
		//Thêm dữ liệu mẫu cho bảng Book:
			modelBuilder.Entity<Book>().HasData(
				new Book { Id = 1, Title = "test", Description="test1", Author="test2", Price = 12, CategoryId = 3, ImageUrl=""});
		}
    }
}
