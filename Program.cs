using AutoShopManager.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Registrar AutoShopContext
builder.Services.AddDbContext<AutoShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AutoShopConnection")));

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapRazorPages();
app.Run();
