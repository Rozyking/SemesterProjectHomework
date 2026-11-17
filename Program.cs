using DaggerheartProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DaggerheartProject.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DaggerheartContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity: the users, and the cookie that remembers who is signed in.
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<DaggerheartContext>();

var app = builder.Build();

// Week 12: the Admin role, and who holds it. Runs once, at startup.
using (var scope = app.Services.CreateScope())
{
    await RoleSeeder.SeedAsync(scope.ServiceProvider);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// A wrong id, or a URL nobody recognizes, used to be a blank browser page.
// This re-runs the request through /Home/Missing and keeps the 404 status.
app.UseStatusCodePagesWithReExecute("/Home/Missing");

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
