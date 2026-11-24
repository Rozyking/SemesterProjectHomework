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

// Week 13: pages only. Under /api, a status is the whole answer, and a page
// of HTML in the body is no use to a program.
app.UseWhen(context => !context.Request.Path.StartsWithSegments("/api"), pages =>
    pages.UseStatusCodePagesWithReExecute("/Home/Missing"));

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Week 13: minimal API endpoint. The same kind of answer as a controller action in one statement
// with no class around it
app.MapGet("/api/Daggerheart/count", async (DaggerheartContext db) =>
    new { count = await db.DaggerheartCharacters.CountAsync() });

app.Run();
