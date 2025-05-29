using AutoShopManager.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Registrar AutoShopContext
builder.Services.AddDbContext<AutoShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AutoShopConnection")));

builder.Services.AddRazorPages();
builder.Services.AddDbContext<AutoShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AutoShopConnection")));

var app = builder.Build();

app.UseAuthentication(); // si usas autenticación
app.UseAuthorization();

app.MapRazorPages();
app.Run();
