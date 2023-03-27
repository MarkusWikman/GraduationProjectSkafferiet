using GraduationProjectSkafferiet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var connString = builder.Configuration
.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>
(o => o.UseSqlServer(connString));

// 1. Registera identity-klasserna och vilken DbContext som ska användas
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
.AddEntityFrameworkStores<ApplicationContext>()
.AddDefaultTokenProviders();

// 2. Specificera att cookies ska användas och URL till inloggnings-sidan
builder.Services.ConfigureApplicationCookie(
o => o.LoginPath = "/login");

var app = builder.Build();

app.UseRouting();

app.UseAuthorization(); // 3. Behörighet

app.UseEndpoints(o => o.MapControllers());
app.UseStaticFiles();

app.Run();
