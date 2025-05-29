using Microsoft.EntityFrameworkCore;
using AutoShopManager.Models;

namespace AutoShopManager.Data
{
    public class AutoShopContext : DbContext
    {
        public AutoShopContext(DbContextOptions<AutoShopContext> options)
            : base(options)
        {
        }

        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reparacion> Reparaciones { get; set; }
        public DbSet<Partes> Partes { get; set; }
        public DbSet<Citas> Citas { get; set; }


    }
}
