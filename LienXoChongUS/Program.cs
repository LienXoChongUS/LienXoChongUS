using LXxUS.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using LXxUS.Utility;
using LXxUS.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity.UI.Services;
using LXxUS.DataAccess.Repository;
using LXxUS.Models;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(c =>
{
    c.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(30);
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddRazorPages();
builder.Services.ConfigureApplicationCookie(option =>
{
    option.LoginPath = $"/Identity/Account/Login";
    option.LogoutPath = $"/Identity/Account/Logout";
    option.AccessDeniedPath = @"/Identity/Account/AccessDenied";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "StoreOwner", "Customer" };
    foreach (var role in roles)
    {
        if (!roleManager.RoleExistsAsync(role).GetAwaiter().GetResult())
        {
            roleManager.CreateAsync(new IdentityRole(role)).GetAwaiter().GetResult();
        }
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    string AD_email = "admin@email.com";
    string SO_email = "storeowner@email.com";
    string AD_phonenumber = "0123456789";
    string SO_phonenumber = "0987654321";
    string AD_pass = "Admin@123";
    string SO_pass = "Storeowner@123";
    string FullName = "Co Nhu Khong";
    string Address = "369 Ngu Nhu Non";
    string City = "Non noi";
    if (userManager.FindByEmailAsync(AD_email).GetAwaiter().GetResult() == null)
    {
        var user = new ApplicationUser();
        user.Email = AD_email;
        user.UserName = AD_email;
        user.Name = FullName;
        user.StreetAddress = Address;
        user.EmailConfirmed = true;
        user.Phone_Number = AD_phonenumber;
        user.City = City;
        userManager.CreateAsync(user, AD_pass).GetAwaiter().GetResult();
        userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();
    }
    if (userManager.FindByEmailAsync(SO_email).GetAwaiter().GetResult() == null)
    {
        var user = new ApplicationUser();
        user.Email = SO_email;
        user.UserName = SO_email;
        user.Name = FullName;
        user.StreetAddress = Address;
        user.Phone_Number = SO_phonenumber;
        user.EmailConfirmed = true;
        user.City = City;
        userManager.CreateAsync(user, SO_pass).GetAwaiter().GetResult();
        userManager.AddToRoleAsync(user, "StoreOwner").GetAwaiter().GetResult();
    }
}
app.Run();